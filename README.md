# KnxChenillard
communicate with a knx system with Csharp


See the file "Projet Chenillard KNX" to know what is it about.

## the framework used 
I'll use a NuGet Framework called KNX.NET by life emotion. The link here : 

https://github.com/lifeemotions/knx.net

## Maquette Address :

The Ip Addresses is  : 192.168.1.5 for maquette 1
						192.168.1.10 for maquette 2
						


Group Addresses Lamps: 0/1/1 (lampe1); 0/1/2 (lampe2); 0/1/3 (lampe3); 0/1/4(lampe4)
Group Addresses Buttons : 0/3/1 (button1); 0/3/2 (button2); 0/3/3 (button3); 0/3/4 (button4)


## How to use the project :

### for the Console Application : 

clone the repository

```
git clone https://github.com/Darchevil/KnxChenillard.git
```

go into the folder ChenillardIotOfficialSolution

```
cd KnxChenillard/src/ChenillardIotOfficialSolution
```

to launch the executable, go into the following folder : 
```
cd KnxChenillard\src\ChenillardIotOfficialSolution\ChenillardIotOfficial\bin\Debug

```
then 
```
ChenillardIotOfficial.exe
```

### for the server 
 clone the repository

clone the repository

```
git clone https://github.com/Darchevil/KnxChenillard.git
```

go into the folder ChenillardIotOfficialSolution

```
cd KnxChenillard/src/Server/ChenillardWebAppSolution
```

Open Visual Studio and import the ChenillardWebAppSolution.sln file

Run the server by running the code with IIS

### Run the client 

Prerequired

Install angular 

```
npm install angular
```

clone the repository

```
git clone https://github.com/Darchevil/KnxChenillard.git
```

go into the ClientAngular folder

```
cd KnxChenillard/ClientAngular/chenillard-client
```

run the client

```
ng serve --open
```

## The Console Application :

Go into the folder called 

```
cd KnxChenillard/src/ChenillardIotOfficialSolution
```

Open visual studio 

Import the ChenillardIotOfficialSolution.sln file

Run the code.

The main files : 
1 - Program.cs
2 - Chenillard.cs
3 - Controls.cs

