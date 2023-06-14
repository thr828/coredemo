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