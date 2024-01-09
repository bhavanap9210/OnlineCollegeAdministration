
Environment & Tools
1. Visual Studio 2012 - 4.5 framework
2. SQL Server 2008 R2
3. Ajaxcontrol toolkit 15.1.30
4. Crystal Report 10.5 

Note: Implemented uploading and displaying of Images for Student and Staff

Hosting on IIS
1. In the Web.Config - Replace the value for IISApplicationFolderName with the folder name hosted in the IIS
2. The C:\Windows\Temp folder needs to have a IIS_USER access. 
	(Right click the C:\Windows\Temp folder- Properties-->Security tab-->Advanced -->Add the Permission for IISUser)
3. In the Web.Config ,in the identity impersonate--> enter the values for User Name and Password(windows authentication-username,password)
4. In the IIS, add username and password -for the website (OnlineCollegeAdministration) - right click -->Advanced Settings--> Credentials--> (windows authentication-username,password)
4. Crystal Report for visual studio(CRforVS_13_0_5.exe) has to be installed

	


