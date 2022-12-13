CREATE DATABASE forfeitbox;

USE forfeitbox;

CREATE TABLE `user` (
  `UserId` varchar(50) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `box` (
  `BoxId` varchar(50) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BoxId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `forfeit` (
  `ForfeitId` varchar(50) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `Sum` double DEFAULT NULL,
  `BoxId` varchar(50) NOT NULL,
  PRIMARY KEY (`ForfeitId`),
  KEY `fk_forfeit_case_idx` (`BoxId`),
  CONSTRAINT `fk_forfeit_box` FOREIGN KEY (`BoxId`) REFERENCES `box` (`BoxId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `user_box` (
  `UserId` varchar(50) NOT NULL,
  `BoxId` varchar(50) NOT NULL,
  `IsAdmin` varchar(45) NOT NULL,
  PRIMARY KEY (`UserId`,`BoxId`),
  KEY `fk_usercase_case_idx` (`BoxId`),
  CONSTRAINT `fk_usercase_case` FOREIGN KEY (`BoxId`) REFERENCES `box` (`BoxId`) ON DELETE CASCADE,
  CONSTRAINT `fk_usercase_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `payment` (
  `PaymentId` varchar(50) NOT NULL,
  `Sum` double DEFAULT NULL,
  `BoxId` varchar(50) NOT NULL,
  `ExecutorId` varchar(50) NOT NULL,
  PRIMARY KEY (`PaymentId`),
  KEY `fk_payment_case_idx` (`BoxId`),
  KEY `fk_payment_executor_idx` (`ExecutorId`),
  CONSTRAINT `fk_payment_case` FOREIGN KEY (`BoxId`) REFERENCES `box` (`BoxId`) ON DELETE CASCADE,
  CONSTRAINT `fk_payment_executor` FOREIGN KEY (`ExecutorId`) REFERENCES `user` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `payment_confirmation` (
  `PaymentConfirmationId` varchar(50) NOT NULL,
  `PaymentId` varchar(50) NOT NULL,
  `ExecutorId` varchar(50) NOT NULL,
  `BoxId` varchar(50) NOT NULL,
  PRIMARY KEY (`PaymentConfirmationId`),
  KEY `fk_paymentconfirmation_payment_idx` (`PaymentId`),
  KEY `fk_paymentconfirmation_user_idx` (`ExecutorId`),
  KEY `fk_paymentconfirmation_case_idx` (`BoxId`),
  CONSTRAINT `fk_paymentconfirmation_case` FOREIGN KEY (`BoxId`) REFERENCES `box` (`BoxId`) ON DELETE CASCADE,
  CONSTRAINT `fk_paymentconfirmation_payment` FOREIGN KEY (`PaymentId`) REFERENCES `payment` (`PaymentId`),
  CONSTRAINT `fk_paymentconfirmation_user` FOREIGN KEY (`ExecutorId`) REFERENCES `user` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `allocation` (
  `AllocationId` varchar(50) NOT NULL,
  `RecieverId` varchar(50) NOT NULL,
  `ForfeitId` varchar(50) NOT NULL,
  `ExecutorId` varchar(50) NOT NULL,
  `BoxId` varchar(50) NOT NULL,
  PRIMARY KEY (`AllocationId`),
  KEY `fk_allocation_user_idx` (`RecieverId`),
  KEY `fk_allocation_forfeit_idx` (`ForfeitId`),
  KEY `fk_allocation_executor_idx` (`ExecutorId`),
  KEY `fk_allocation_case_idx` (`BoxId`),
  CONSTRAINT `fk_allocation_case` FOREIGN KEY (`BoxId`) REFERENCES `box` (`BoxId`) ON DELETE CASCADE,
  CONSTRAINT `fk_allocation_executor` FOREIGN KEY (`ExecutorId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `fk_allocation_forfeit` FOREIGN KEY (`ForfeitId`) REFERENCES `forfeit` (`ForfeitId`),
  CONSTRAINT `fk_allocation_reciever` FOREIGN KEY (`RecieverId`) REFERENCES `user` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
