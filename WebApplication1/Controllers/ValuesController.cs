using Domain.Interfaces.Services;
using DTO;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IArtcleService _artcleService;
        private readonly IDistributedCache _distributedCache;//分布式缓存接口

        public ValuesController(IArtcleService artcleService, IDistributedCache distributedCache)
        {
            _artcleService = artcleService;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {

            var list = GetShoppingCarts();
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Gid = 3,
            };
            bool a = AddGoods(shoppingCart);
            //将对象序列化字符串 添加到redis中
            //当下存入的为string形式 ,需要对添加的数据序列化

            return _artcleService.GetAllActive();
        }

        // 添加购物车  或更改购买数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool  AddGoods(ShoppingCart s)
        {
            //先定义List列表  因为返回的数据也是放入列表中的便于后面查询，所以添加的也应该是列表
            List<ShoppingCart> list = new List<ShoppingCart>();

            //去Redis中查找数据  //根据键名查找  获取的Key为一个数组列表格式
            string? key = _distributedCache.GetString("ShoppingCart");

            //如果是key为NULL   代表是第一次访问Redis
            if (string.IsNullOrEmpty(key))
            {
                //先将对象存储到list中
                list.Add(s);
                //对列表序列化   前提下载包json 引用 using Newtonsoft.Json;
                var json = JsonConvert.SerializeObject(list);

                //将对象序列化字符串 添加到redis中
                _distributedCache.SetString("ShoppingCart", json);
            }
            else //代表key有值  则进行 查找
            {
                //先将Key反序列化为对象
                var listDes = JsonConvert.DeserializeObject<List<ShoppingCart>>(key);
                //根据题意获取是否购物车中有此商品
                var item = listDes.FirstOrDefault(u => u.Gid == s.Gid);
                if (item != null)
                {
                    item.BuyNum += 1;
                    //判断是否假删除  此步缘由与根据题意编辑
                    if (item.IsDelete == 1)
                    {
                        item.BuyNum = 1;
                        item.IsDelete = 0;
                    }
                    //将修改后的数据所在的整个对象序列化字符串 添加到redis中
                    var json = JsonConvert.SerializeObject(listDes);
                    _distributedCache.SetString("ShoppingCart", json,new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(15)));
                }
                //不存在 添加新的数据到购物车
                else
                {
                    //将对象存储到返回时序列化后的listDes中
                    listDes.Add(s);
                    //将对象序列化字符串 添加到redis中
                    var json = JsonConvert.SerializeObject(listDes);
                    _distributedCache.SetString("ShoppingCart", json);
                }

            }

     //       _distributedCache.SetString("shoppingCar",
     // JsonConvert.SerializeObject(list),
     //new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5)));  //设置超时时间5后过期

            return true;
        }

        public List<ShoppingCart> GetShoppingCarts()
        {
            //去Redis中查找数据  //根据键名查找  获取的Key为一个数组列表格式
            string? key = _distributedCache.GetString("ShoppingCart");
            //如果是key为NULL   代表是第一次访问Redis
            if (string.IsNullOrEmpty(key))
            {
                //从数据库读取数据
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    Gid = 3,
                };
                List<ShoppingCart> list = new List<ShoppingCart>();
                list.Add(shoppingCart);
                var json = JsonConvert.SerializeObject(list);
                //将对象序列化字符串 添加到redis中
                _distributedCache.SetString("ShoppingCart", json);
                return list;
            }
            else
            {
                var listDes = JsonConvert.DeserializeObject<List<ShoppingCart>>(key);
                return listDes;
            }
        }
    } 
}
