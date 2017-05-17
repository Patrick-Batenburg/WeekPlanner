-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.23-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for taskdb
CREATE DATABASE IF NOT EXISTS `taskdb` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `taskdb`;

-- Dumping structure for table taskdb.appointments
CREATE TABLE IF NOT EXISTS `appointments` (
  `Id` int(10) unsigned NOT NULL,
  `UserId` int(10) unsigned NOT NULL,
  `Description` varchar(64) NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table taskdb.grades
CREATE TABLE IF NOT EXISTS `grades` (
  `RowIndex` int(10) unsigned NOT NULL,
  `UserId` int(10) unsigned NOT NULL,
  `ColumnIndex` int(10) unsigned NOT NULL,
  `Number` float unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`RowIndex`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `SubjectFK` FOREIGN KEY (`RowIndex`) REFERENCES `subjects` (`RowIndex`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table taskdb.subjects
CREATE TABLE IF NOT EXISTS `subjects` (
  `RowIndex` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(10) unsigned NOT NULL,
  `Name` varchar(64) NOT NULL,
  PRIMARY KEY (`RowIndex`),
  UNIQUE KEY `RowIndex` (`RowIndex`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table taskdb.tasks
CREATE TABLE IF NOT EXISTS `tasks` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserId` int(10) unsigned NOT NULL,
  `Title` varchar(64) NOT NULL,
  `Date` date NOT NULL,
  `Duration` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Repeats` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `Label` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserFK` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table taskdb.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Username` varchar(64) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `Role` varchar(64) NOT NULL DEFAULT 'Member',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
