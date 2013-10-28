# Api and DB Server Setup #

----------

Windows server host the DB and the api.
The api serves and receives json as an input parameter.

Here is an example fiddler call to the live api

    POST https://live.api.raftcarinthia.com/0.0.1/web/user/login HTTP/1.1
    User-Agent: Fiddler
    content-type: application/json
    client-token: 4CA19E2D-AFA4-407E-BC5C-9BBE58841919
    Host: live.api.raftcarinthia.com
    Content-Length: 43
    
    {
    "email":"asdf@asdf.com",
    "pwd":"adf"
    }
    
Note the client-token this is the security token which is in the settings table of the DB and is required for api access.

# Connecting to the live windows API/DB machine machine #

----------

Windows server RDP connection
server: ufostartapiff.cloudapp.net
user: Jens
pwd: UfoStart2013.


open SQL management studio
connect to feuerbach instance
user: Jens
pwd: UfoStart2013.
Db: ufo_live


# Setting up the Database and API #
Create a new window vm from the UfoStartFF.
Make sure you open port 443 for ssl
<img src="https://raw.github.com/UFOstart/UFOStartApi/master/docs/UfoStartHttpsPort.PNG"/>

When it is finished creating click on dashboard and click connect
then rdp with the user you have created.

## Setting up the API ##
look in c:/IISCreateSSSIite.ps1
this script creates the website that runs the api.

    import-module webadministration
    remove-item IIS:\Sites\UFOStart.Api -recurse
    remove-item IIS:\AppPools\UfoStartAppPool -recurse
    New-Item IIS:\AppPools\UfoStartAppPool
    Set-ItemProperty IIS:\AppPools\UfoStartAppPool managedRuntimeVersion v4.5
    New-Item IIS:\Sites\UFOStart.Api -bindings @{protocol="https";bindingInformation=":443:your.api.domain.com} -physicalPath c:\inetpub\wwwroot\
    Set-ItemProperty IIS:\Sites\UFOStart.Api -name applicationPool -value UfoStartAppPool

You need to update the your.api.domain.com to the site that your dns provider is using.
You can get the public virtual ip address from the new server from azure VM dashboard.

<img src="https://raw.github.com/UFOstart/UFOStartApi/master/docs/UFOAzureIp.PNG"/>

run this powershell script

Then into the server manager/webserver/iissite and find ufostart.api
right click and go to edit bindings. find the binding and select edit.
Then select the ssl cert with the same name as the new machine and click save.
check the ufostart app pool is running version 4.0 and is started. 

You should now be able to browse to the url and get a iis default page.

## Setting up the Database ##
First get an up to date  backup to restore on the new sql sever.
After the restore you need to create the ufo_user with pwd that is configured in <code>UfoStart.Api-->Web.config</code>, and in <code>UFOStart.MailQueue-->App.config</code> (in the respective C# projects).
Now we need to sync the user in the backup with the newly created login with 
    exec sp_change_users_login 'Update_One', 'ufo_user', 'ufo_user'


The api should now be able to connect to the DB.
The setup the front end to point to the api url


information 
in the db there is settings table
you can only connect to the api if you have the client-token found in the settings table. This goes in the header of the http request.


###Restart mail queue###

If you want to restart mail queue, restart the service as in the screen shot.

 <img src="https://raw.github.com/UFOstart/UFOStartApi/master/docs/UfoStartMailQueue.PNG"/>