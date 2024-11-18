# BloodBankWebAPI

Steps to run the application:

1. `git clone https://github.com/shashanksola/BloodBankWebAPI`
2. Open the folder in Visual Studio using `start devenv` in command prompt.
3. Select this option
<img width="298" alt="image" src="https://github.com/user-attachments/assets/f43a2532-0cc8-432a-b3fc-4d66a8785c9b">

4. Select the .sln (solution file) in the cloned project folder.
<img width="630" alt="image" src="https://github.com/user-attachments/assets/9e042164-637a-4917-b9b8-76f88f69a1f2">

5. Click the https run button to start the API Server.
<img width="1280" alt="image" src="https://github.com/user-attachments/assets/45745c31-ccbc-469e-acdb-3b47a0397929">

6. Swagger will be opened automatically, any CRUD operations can be performed there, or we can use Postman
![image](https://github.com/user-attachments/assets/c9f12cc8-5306-4901-be8f-e17b6b98356e)

# Example run using Postman & Swagger

## POST: api/BloodBank
Valid Input:
![image](https://github.com/user-attachments/assets/e213bcab-9183-45d9-befb-98f9f27d8be9)

Invalid Input:
![image](https://github.com/user-attachments/assets/eb8738f2-4132-4b71-87af-46c4718b1c22)

## GET: api/BloodBank

![image](https://github.com/user-attachments/assets/701befc6-a54e-4bd3-9b7e-c57ab7ccda41)

When no entries are available:
![image](https://github.com/user-attachments/assets/a7ac72ad-82cc-4d02-a737-dadcef200216)

## GET: api/BloodBank/{id}
![image](https://github.com/user-attachments/assets/af7eb7cb-1210-4c83-9d4f-b90784c4b715)

When Id Not available:
![image](https://github.com/user-attachments/assets/e47ce977-0b07-4dcf-99ab-11bbcfb40f8c)

## PUT: api/BloodBank/{id}
![image](https://github.com/user-attachments/assets/1b2e8d3a-12dd-443b-b1af-15360fc688cd)

Invalid PUT request:
![image](https://github.com/user-attachments/assets/2d4360e2-da89-4718-a666-821e80ad4298)

## DELETE: api/BloodBank/{id}
![image](https://github.com/user-attachments/assets/a95beec0-a6ae-4e2c-8174-3740ef610d6f)

When No entry is present
![image](https://github.com/user-attachments/assets/4a6a057a-d8e4-43e3-8789-0211137dd902)

## GET: api/BloodBank/paged
![image](https://github.com/user-attachments/assets/99d06163-759d-42b9-8209-bd5bcad02feb)

## GET: api/BloodBank/search

search accepts any valid parameter such as bloodType, status or donorName
![image](https://github.com/user-attachments/assets/b0f229fa-c83c-419e-b1ce-b1e219575292)

## GET: api/BloodBank/sorted

Sorted accepts any parameter of BloodBankEntry Model (input should be in PascalCase)
![image](https://github.com/user-attachments/assets/bcf17053-511d-4516-8862-0f9c2c888219)
