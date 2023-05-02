# ChangeFeedProcessor
This is high level .Net powered POC to show use of Azure Cosmos DB Change as a mechanism to orchestrate a two way SMS communication architecture using Azure Communication Services. Note - Built for Azure Cosmos DB Global User Group Event.
# Getting Started

Installation process
1. Create a NoSQL Azure Cosmos DB - https://learn.microsoft.com/en-us/azure/cosmos-db/try-free?tabs=nosql
2. Create an instance of Azure Communication Services with a Phone Number which can send and receive SMS - https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
3. You will need to bind MessageReceiver funtion to Comm. Services - https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/sms/receive-sms?pivots=platform-power
4. Create an Azure Function App instance to run funtions apps on Azure and Publish code provided in this repo - https://learn.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio?tabs=in-process#publish-the-project-to-azure
Note - You can comment out DataLoader functions app before deployement because it is used in local environemnt to add records to the databse and simulate workflow.

Add following COnfiguraitns settings to your Fn App 

    "CosmosDBConnectionSetting": "Your Cosmos Conn String",
    
    "ParticipantPhoneNumber": "Phone Number where you want to send Text Message",
    
    "CommConnectionString": "Communication Service Conn. String",
    
    "TeamPhoneNumber": "Communication Service Phone Number which will send texts",
    
    "DataBaseId": "Your Azure Cosmos DB ID",
    
    "ContainerIdMessage": "Your COnatiner to Store Texts",
    
    "ContainerIdActivity": "Your Container to store Aactivity"
    


# Build and Test
Once you have deployed your function app, you will need to comment our all functions in local build except DataLoader.
DataLoader function is an Http trigger funtion which will add 2 records to your database. Once these recordsa are added, other functions will get triggers in Azure and your workflow kick off.
Note : You can run All Cosmos Trigger functions locally but QueueTrigger function needs to be deployed and configured with Comm Services to response to Text Messages.
