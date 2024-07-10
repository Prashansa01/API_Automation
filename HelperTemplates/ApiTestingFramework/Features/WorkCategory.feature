Feature: WorkCategory

    This is to demostrate the various ways to verify data with bearer token authentication 

Scenario: POST request to post data on WorkCategory kafka endpoint
	Given Kafka json input file for WorkCategory
	| FileName |
	| TestData\Environment\GetWCKafkaFeed.json   |
        When User sends POST request
	Then Validate Status Code should be 200	 

Scenario: Get request to retrive data for the unique key  
	Given User makes GET Request with key'5aa9f00b-cdb8-5c65-baa7-42520533f604'
	Then User receives API response in json input file with single data
	| FileName |
	| TestData\Environment\GetKeyWC.json|
	And Validate the json resopnse and Status Code should be 200

Scenario: GET Request to retrieve response and validate using test json file 
        Given User sends a GET Request to retrieve json response
        Then User receives API response with json input file
	| FileName |
	| TestData\Environment\GetAllWC.json|
	And Validate the json resopnse and Status Code should be 200

Scenario:  GET Request to count the number of response data
        Given User sends GET request to retrieve  count of WorkCategory response data
	Then User receives API response with json input file
	| FileName |
	| TestData\Environment\GetAllWC.json|
	Then Validate the json response and Status Code should be 200

Scenario: GET Request with invalid EndPoints
        Given User sends GET request with invalid EndPoint  
	Then User recieves no response for invalid end point
	And Validate the Status Code should be 404

Scenario: GET Request with invalid Authorisation
	Given User sends GET request with invalid Bearer Token
	Then User recieves no response for invalid token
	And Validate the Status Code should be 401
	 
