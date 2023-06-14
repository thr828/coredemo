# coredemo
# cap 监控地址：http://localhost:5180/cap/index.html
# swagger地址：http://localhost:5180/swagger/index.html 
# 技术栈：
# EntityFramework Core
# IOC(DI)
# AutoMapper
# Redis(作为分布式缓存时使用，使用IDistributedCache)
# CAP(分布式事务，结合RabbitMq作为消息队列、同时会自动创建本地消息表)，会自动实现重试机制
# 多语言（访问地址：http://localhost:5180/weatherforecast?culture=zh-Hans http://localhost:5180/weatherforecast?culture=en-US）

# 知识点部分
# 1.Run用于注册终端中间件，Use用来注册匿名中间件，UseWhen、Map、MapWhen用于创建管道分支。
# 2.UseWhen进入管道分支后，如果管道分支中不存在短路或终端中间件，则会返回到主管道。Map和MapWhen进入管道分支后，无论如何，都不会再返回到主管道。
# 3.UseWhen和MapWhen基于逻辑条件来创建管道分支，而Map基于请求路径来创建管道分支，且会对HttpRequest.Path和HttpRequest.PathBase进行处理。