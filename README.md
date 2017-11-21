# HelloWorldApp
A sample hello world app in c# asp.net, print message to console or save to database, sample web api included.

## Usage
-----------
1) Print message to console
```C#
Message msg = new Message();
msg.setMsg("Hello World");
msg.Execute();
```

2) Save to db
```C#
Message msg2 = new Message();
msg2.setPlatform(new DatabaseRepository());
msg2.setMsg("this data");
msg2.Execute();
```

Really simple stuff, just for education purposes only.