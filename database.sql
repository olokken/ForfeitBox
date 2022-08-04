CREATE TABLE `user` (
  `UserId` varchar(50) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `case` (
  `CaseId` varchar(50) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CaseId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `forfeit` (
  `ForfeitId` varchar(50) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `Sum` double DEFAULT NULL,
  PRIMARY KEY (`ForfeitId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `allocation` (
  `AllocationId` varchar(50) NOT NULL,
  `RecieverId` varchar(50) NOT NULL,
  `ForfeitId` varchar(50) NOT NULL,
  `ExecutorId` varchar(50) NOT NULL,
  PRIMARY KEY (`AllocationId`),
  KEY `fk_allocation_user_idx` (`RecieverId`),
  KEY `fk_allocation_forfeit_idx` (`ForfeitId`),
  KEY `fk_allocation_executor_idx` (`ExecutorId`),
  CONSTRAINT `fk_allocation_executor` FOREIGN KEY (`ExecutorId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `fk_allocation_forfeit` FOREIGN KEY (`ForfeitId`) REFERENCES `forfeit` (`ForfeitId`),
  CONSTRAINT `fk_allocation_reciever` FOREIGN KEY (`RecieverId`) REFERENCES `user` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `payment` (
  `PaymentId` varchar(50) NOT NULL,
  `Sum` double DEFAULT NULL,
  `CaseId` varchar(50) NOT NULL,
  `ExecutorId` varchar(50) NOT NULL,
  PRIMARY KEY (`PaymentId`),
  KEY `fk_payment_case_idx` (`CaseId`),
  KEY `fk_payment_executor_idx` (`ExecutorId`),
  CONSTRAINT `fk_payment_case` FOREIGN KEY (`CaseId`) REFERENCES `case` (`CaseId`) ON DELETE CASCADE,
  CONSTRAINT `fk_payment_executor` FOREIGN KEY (`ExecutorId`) REFERENCES `user` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `user_case` (
  `UserId` varchar(50) NOT NULL,
  `CaseId` varchar(50) NOT NULL,
  `IsAdmin` varchar(45) NOT NULL,
  PRIMARY KEY (`UserId`,`CaseId`),
  KEY `fk_usercase_case_idx` (`CaseId`),
  CONSTRAINT `fk_usercase_case` FOREIGN KEY (`CaseId`) REFERENCES `case` (`CaseId`) ON DELETE CASCADE,
  CONSTRAINT `fk_usercase_user` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;