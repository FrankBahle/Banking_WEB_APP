CREATE TABLE Register_Client(
Register_Client_ID_Passport VARCHAR(255) NOT NULL,
Register_Client_Name VARCHAR(240),
Register_Client_Surname VARCHAR(240),
Register_Client_Email VARCHAR(240),
Register_Client_Phone_Number VARCHAR(255),
Register_Client_Account_Type VARCHAR(240),
Register_Client_Pass_Word VARCHAR(240),
Register_Client_Confirm_Pass_Word  VARCHAR(240),
Register_Client_Status VARCHAR(240),
PRIMARY KEY(Register_Client_ID_Passport)
);

                                          
CREATE TABLE Admin_Manager(
Admin_Manager_ID VARCHAR(255) PRIMARY KEY NOT NULL ,
Admin_Manager_Name VARCHAR(255),
Admin_Manager_Pass_Word VARCHAR(255)
);


INSERT INTO Admin_Manager(Admin_Manager_ID,Admin_Manager_Name,Admin_Manager_Pass_Word) VALUES
('456789','Frank','FrankBahle');

INSERT INTO Register_Client (
    Register_Client_ID_Passport,
    Register_Client_Name,
    Register_Client_Surname,
    Register_Client_Email,
    Register_Client_Phone_Number,
    Register_Client_Account_Type,
    Register_Client_Pass_Word,
    Register_Client_Confirm_Pass_Word,
    Register_Client_Status
) VALUES
('ID1234567890', 'John', 'Doe', 'john.doe@example.com', '0831234567', 'Savings', 'Pass@123', 'Pass@123', 'Pending'),
('ID9876543210', 'Jane', 'Smith', 'jane.smith@example.com', '0822345678', 'Cheque', 'Secure#456', 'Secure#456', 'Pending'),
('ID1122334455', 'Michael', 'Johnson', 'michael.johnson@example.com', '0613456789', 'Fixed', 'MyPass789!', 'MyPass789!', 'Pending'),
('ID5566778899', 'Emily', 'Brown', 'emily.brown@example.com', '0724567890', 'Savings', 'EmilyPass2023', 'EmilyPass2023', 'Pending'),
('ID9988776655', 'Daniel', 'Wilson', 'daniel.wilson@example.com', '0735678901', 'Cheque', 'Wilson@321', 'Wilson@321', 'Pending');








<-------------CHEQUE_ACCOUNT------------>



CREATE TABLE Cheque_Account (
    Account_Number VARCHAR(255),
    Register_Client_ID_Passport VARCHAR(255),
    Current_Amount DECIMAL,
    Account_Created_At DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (Register_Client_ID_Passport) REFERENCES Register_Client
);



INSERT INTO Cheque_Account (
    Account_Number, Register_Client_ID_Passport, Current_Amount
) VALUES
('CH001', 'ID9876543210', 12000.00),
('CH002', 'ID9988776655', 8500.00),
('CH003', 'ID9876543210', 9200.50),
('CH004', 'ID9988776655', 11000.00),
('CH005', 'ID9876543210', 7400.00);





<-------------------FIXED_ACCOUNT-------------------->


CREATE TABLE Fixed_Account (
    Account_Number VARCHAR(255),
    Register_Client_ID_Passport VARCHAR(255),
    Current_Amount DECIMAL,
    Account_Created_At DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (Register_Client_ID_Passport) REFERENCES Register_Client
);

CREATE TABLE Transaction_Fixed (
 Transaction_Fixed_ID INT IDENTITY(1,2) PRIMARY KEY,
    Account_Number VARCHAR(255),
    Transaction_Date_Time DATETIME NOT NULL DEFAULT GETDATE(),
    Transaction_Current_Amount DECIMAL,
    Transaction_Transfer DECIMAL,
    Transaction_Deposite DECIMAL,
    Transaction_Foreign_Account_Number VARCHAR(255)
);


INSERT INTO Transaction_Fixed (
    Account_Number,
    Transaction_Current_Amount,
    Transaction_Transfer,
    Transaction_Deposite,
    Transaction_Foreign_Account_Number
) VALUES
('FX001', 5000.00, NULL, 1000.00, 'FX002'),
('FX002', 3000.00, NULL, 500.00, 'FX003'),
('FX003', 10000.00, NULL, 2500.00, 'FX004'),
('FX004', 7500.00, NULL, 1250.00, 'FX001'),
('FX005', 2000.00, NULL, 2000.00, 'FX006');


INSERT INTO Fixed_Account (
    Account_Number, Register_Client_ID_Passport, Current_Amount
) VALUES
('FX001', 'ID1122334455', 20000.00),
('FX002', 'ID1122334455', 18000.00),
('FX003', 'ID1122334455', 25000.00),
('FX004', 'ID1122334455', 30000.00),
('FX005', 'ID1122334455', 22000.00);



<----------------SAVING---------------------->
CREATE TABLE Savings_Account (
    Account_Number VARCHAR(255),
    Register_Client_ID_Passport VARCHAR(255),
    Current_Amount DECIMAL,
    Account_Created_At DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (Register_Client_ID_Passport) REFERENCES Register_Client
);

CREATE TABLE Transaction_Savings (
    Transaction_Savings_ID INT IDENTITY(1,2) PRIMARY KEY,
    Account_Number VARCHAR(255),
    Transaction_Date_Time DATETIME NOT NULL DEFAULT GETDATE(),
    Transaction_Current_Amount DECIMAL,
    Transaction_Transfer DECIMAL,
    Transaction_Deposite DECIMAL,
    Transaction_Foreign_Account_Number VARCHAR(255)
);

INSERT INTO Transaction_Savings (
    Account_Number,
    Transaction_Current_Amount,
    Transaction_Deposite,
    Transaction_Foreign_Account_Number
) VALUES
('SA001', 15000.00, 2000.00, 'SA002'),
('SA002', 8000.00, 1500.00, 'SA003'),
('SA003', 12000.00, 3000.00, 'SA004'),
('SA004', 9500.00, 500.00, 'SA001'),
('SA005', 5000.00, 2500.00, 'SA003');


INSERT INTO Savings_Account (
    Account_Number, Register_Client_ID_Passport, Current_Amount
) VALUES
('SA001', 'ID1234567890', 2500.00),
('SA002', 'ID5566778899', 5400.50),
('SA003', 'ID1234567890', 1800.75),
('SA004', 'ID5566778899', 3200.00),
('SA005', 'ID1234567890', 6000.00);


CREATE TABLE Transaction_Cheque (
    Transaction_Cheque_ID INT IDENTITY(1,2) PRIMARY KEY,
    Account_Number VARCHAR(255),
    Transaction_Date_Time DATETIME NOT NULL DEFAULT GETDATE(),
    Transaction_Current_Amount DECIMAL,
    Transaction_WithDrawal DECIMAL,
    Transaction_Transfer DECIMAL,
    Transaction_Deposite DECIMAL,
    Transaction_Foreign_Account_Number VARCHAR(255)
);

INSERT INTO Transaction_Cheque (
    Account_Number,
    Transaction_Current_Amount,
    Transaction_WithDrawal,
    Transaction_Transfer,
    Transaction_Deposite,
    Transaction_Foreign_Account_Number
) VALUES
('CH001', 12000.00, 800.00, NULL, NULL, NULL),
('CH002', 8500.00, NULL, NULL, 600.00, 'CH003'),
('CH003', 9200.50, 450.00, NULL, NULL, NULL),
('CH004', 11000.00, NULL, NULL, 1000.00, 'CH001'),
('CH005', 7400.00, 950.00, NULL, NULL, NULL);


SELECT * FROM Transaction_Cheque WHERE Account_Number = 'CH0001';
