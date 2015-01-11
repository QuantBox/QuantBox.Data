# QuantBox.Data数据存储格式

##介绍
自定义的二进制行情数据存储格式，支持兼容Bar和Tick数据，支持无限深度行情。将行情使用此格式编码后再用7z或zip压缩后再存储。

## 项目文件介绍
1. **QuantBox\.Data\.Serializer**,编解码库
2. **Test**,测试用例
3. **DataInspector**,数据文件查看、编译、转换工具

## 在自己的项目中使用
引用**QuantBox\.Data\.Serializer**库即可，参考**DataInspector**中的使用方法，再转换成自己系统中的数据格式