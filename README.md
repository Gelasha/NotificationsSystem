# NotificationsSystem
You can call CreateCompany Api(https://localhost:44394/api/Notifications/CreateCompany) and CreateSchedule Api(https://localhost:44394/api/Notifications/CreateSchedule)

  CreateCompany request example:

		{
		    "ConmpanyName": "Test",
		    "ConmpanyNumber": "1231231231",
		    "Market": "Denmark",
		    "CompanyType": "Large"
		}

	CreateSchedule request example:
  
		{
		    "Id": "172e3c04-eeb3-403f-ba86-ad2dcccddbee",
		    "ConmpanyName": "Test",
		    "ConmpanyNumber": "12312312311",
		    "Market": "Denmark",
		    "CompanyType": "Small"
		}
