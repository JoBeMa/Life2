CREATE DATABASE  IF NOT EXISTS `life_2_0` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `life_2_0`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: life_2_0
-- ------------------------------------------------------
-- Server version	5.5.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `files`
--

DROP TABLE IF EXISTS `files`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `files` (
  `idfiles` int(11) NOT NULL AUTO_INCREMENT,
  `fileName` varchar(100) DEFAULT NULL,
  `Offer` int(11) DEFAULT NULL,
  `Url` varchar(950) DEFAULT NULL,
  `Userid` int(11) DEFAULT NULL,
  PRIMARY KEY (`idfiles`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `promoter_skills`
--

DROP TABLE IF EXISTS `promoter_skills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `promoter_skills` (
  `Skill_id` int(11) NOT NULL AUTO_INCREMENT,
  `Skill_name` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Promoter_id` int(11) DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Skill_id`)
) ENGINE=InnoDB AUTO_INCREMENT=616 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `stat`
--

DROP TABLE IF EXISTS `stat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stat` (
  `idStat` int(11) NOT NULL AUTO_INCREMENT,
  `Event` varchar(50) DEFAULT NULL,
  `User_login` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `dTime` timestamp NULL DEFAULT NULL,
  `duration` int(11) DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `Device` varchar(450) DEFAULT NULL,
  `query` varchar(450) CHARACTER SET latin1 DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`idStat`)
) ENGINE=InnoDB AUTO_INCREMENT=80726 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `hub`
--

DROP TABLE IF EXISTS `hub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hub` (
  `Hub_id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(450) DEFAULT NULL,
  `User_id` int(11) DEFAULT NULL,
  `Area` int(11) DEFAULT NULL,
  `Hub_average_mark` float DEFAULT NULL,
  `Hub_votes` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Category` int(11) DEFAULT NULL,
  `Address` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`Hub_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_profile`
--

DROP TABLE IF EXISTS `user_profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_profile` (
  `User_id` int(11) NOT NULL AUTO_INCREMENT,
  `Login` varchar(45) CHARACTER SET latin1 NOT NULL DEFAULT '""',
  `uid` varchar(45) CHARACTER SET latin1 DEFAULT '""',
  `Role` int(11) DEFAULT NULL,
  `Password` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `userpassword` varchar(45) CHARACTER SET latin1 NOT NULL,
  `Name` varchar(85) CHARACTER SET latin1 DEFAULT NULL,
  `cn` varchar(85) CHARACTER SET latin1 DEFAULT NULL,
  `givenname` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `sn` varchar(30) CHARACTER SET latin1 DEFAULT NULL,
  `Picture` varchar(245) CHARACTER SET latin1 DEFAULT NULL,
  `email` varchar(145) CHARACTER SET latin1 DEFAULT NULL,
  `Language` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Home_area_lat` double DEFAULT NULL,
  `Home_area_lon` double DEFAULT NULL,
  `Home_area_radius` double DEFAULT NULL,
  `Last_loc_timestamp` timestamp NULL DEFAULT NULL,
  `Last_loc_lat` double DEFAULT NULL,
  `last_loc_lon` double DEFAULT NULL,
  `Notification_level` int(11) DEFAULT NULL,
  `Promoter_id` int(11) DEFAULT NULL,
  `User_average_mark` float DEFAULT '0',
  `User_votes` int(11) DEFAULT '0',
  `Enabled` int(11) DEFAULT '1',
  `ChangePassword` varchar(40) CHARACTER SET latin1 DEFAULT NULL,
  `sunIdentityMSISDNNumber` int(11) DEFAULT NULL,
  `manager` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `telephonenumber` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `preferredlocale` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_alias_list` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `inetuserstatus` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_auth_config` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_account_life` varchar(20) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_password_reset_force_reset` int(11) DEFAULT NULL,
  `iplanet_am_user_password_resetoptions` int(11) DEFAULT NULL,
  `iplanet_am_user_password_reset_question_answer` varchar(60) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_success_url` varchar(40) CHARACTER SET latin1 DEFAULT NULL,
  `iplanet_am_user_failure_url` varchar(40) CHARACTER SET latin1 DEFAULT NULL,
  `skillsVisibility` int(11) DEFAULT NULL,
  `interestsVisibility` int(11) DEFAULT NULL,
  `region` varchar(800) DEFAULT '0',
  `address` varchar(80) DEFAULT NULL,
  `adminRegion` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`User_id`,`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=577 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `promoters`
--

DROP TABLE IF EXISTS `promoters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `promoters` (
  `Promoters_id` int(11) NOT NULL AUTO_INCREMENT,
  `Availability` int(11) DEFAULT NULL,
  `Area` int(11) DEFAULT NULL,
  `Promoter_average_mark` float DEFAULT NULL,
  `Promoter_votes` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Promoters_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_interests`
--

DROP TABLE IF EXISTS `user_interests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_interests` (
  `interest_id` int(11) NOT NULL AUTO_INCREMENT,
  `interest_name` varchar(45) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `lng` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`interest_id`)
) ENGINE=InnoDB AUTO_INCREMENT=207 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `company_category`
--

DROP TABLE IF EXISTS `company_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company_category` (
  `Category_id` int(11) NOT NULL AUTO_INCREMENT,
  `Category_name` varchar(45) DEFAULT NULL,
  `Category_description` mediumtext,
  `Status` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `joins`
--

DROP TABLE IF EXISTS `joins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `joins` (
  `idJoin` int(11) NOT NULL AUTO_INCREMENT,
  `Id` int(11) DEFAULT NULL,
  `User_id` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  PRIMARY KEY (`idJoin`)
) ENGINE=InnoDB AUTO_INCREMENT=165 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `promoter_tools`
--

DROP TABLE IF EXISTS `promoter_tools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `promoter_tools` (
  `Tool_id` int(11) NOT NULL AUTO_INCREMENT,
  `Tool_name` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Promoter_id` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Tool_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `Category_id` int(11) NOT NULL AUTO_INCREMENT,
  `Category_name` varchar(45) DEFAULT NULL,
  `Category_description` mediumtext,
  `Status` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=245 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_contacts`
--

DROP TABLE IF EXISTS `user_contacts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_contacts` (
  `User_id` int(11) NOT NULL AUTO_INCREMENT,
  `Contact_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`User_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `Log_id` int(11) NOT NULL AUTO_INCREMENT,
  `Log_type` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `User_type` int(11) DEFAULT NULL,
  `User_id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Category_id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request` (
  `RequestId` int(11) NOT NULL AUTO_INCREMENT,
  `RequesterId` int(11) DEFAULT NULL,
  `RequestType` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Category_Id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Short_description` mediumtext CHARACTER SET latin1,
  `Description` mediumtext CHARACTER SET latin1,
  `WhenReq` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `WhereReq` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `FilteringPrefs` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `Deadline` timestamp NULL DEFAULT NULL,
  `Candidates` varchar(450) CHARACTER SET latin1 DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `SubmissionDate` timestamp NULL DEFAULT NULL,
  `ContactType` int(11) DEFAULT NULL,
  PRIMARY KEY (`RequestId`)
) ENGINE=InnoDB AUTO_INCREMENT=468 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `regions`
--

DROP TABLE IF EXISTS `regions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(450) DEFAULT NULL,
  `country` varchar(450) DEFAULT NULL,
  `country_code` varchar(3) DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `radius` double DEFAULT NULL,
  `lng` varchar(45) DEFAULT NULL,
  `supraRegion` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `catalogue`
--

DROP TABLE IF EXISTS `catalogue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `catalogue` (
  `Offer_id` int(11) NOT NULL AUTO_INCREMENT,
  `Offer_type` int(11) DEFAULT NULL,
  `Category_id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Promoter_id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Title` varchar(450) DEFAULT NULL,
  `Short_description` mediumtext CHARACTER SET latin1,
  `Detailed_info` mediumtext CHARACTER SET latin1,
  `DateOfActivity` datetime DEFAULT NULL,
  `WhenCat` varchar(100) CHARACTER SET latin1 DEFAULT NULL,
  `WhereCat` varchar(245) CHARACTER SET latin1 DEFAULT NULL,
  `Deadline` timestamp NULL DEFAULT NULL,
  `Offer_average_mark` float DEFAULT NULL,
  `Offer_votes` int(11) DEFAULT NULL,
  `lat` double DEFAULT NULL,
  `lon` double DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `request_id` int(11) DEFAULT '-1',
  `Candidates` varchar(245) CHARACTER SET latin1 DEFAULT NULL,
  `SubmissionDate` timestamp NULL DEFAULT NULL,
  `ContactType` int(11) DEFAULT NULL,
  `OrgName` varchar(450) DEFAULT NULL,
  `Address` varchar(450) DEFAULT NULL,
  `Telephone` varchar(45) DEFAULT NULL,
  `Mobile` varchar(45) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `url_booking` varchar(450) DEFAULT NULL,
  `url_web` varchar(450) DEFAULT NULL,
  `url_brochure` varchar(450) DEFAULT NULL,
  `Price` varchar(450) DEFAULT NULL,
  `Subscription` tinyint(4) DEFAULT NULL,
  `MaxParticipants` int(11) DEFAULT NULL,
  `Views` int(11) DEFAULT '0',
  `ViewsHist` text,
  `url_booking_dsc` varchar(200) DEFAULT NULL,
  `url_web_dsc` varchar(200) DEFAULT NULL,
  `url_brochure_dsc` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Offer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1952 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `recommendations`
--

DROP TABLE IF EXISTS `recommendations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recommendations` (
  `recid` int(11) NOT NULL AUTO_INCREMENT,
  `Offer_id` int(11) NOT NULL,
  `Request_id` int(11) DEFAULT NULL,
  `User_id` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Comment` mediumtext CHARACTER SET latin1,
  `RecList` varchar(4500) CHARACTER SET latin1 DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`recid`)
) ENGINE=InnoDB AUTO_INCREMENT=966 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `small_business`
--

DROP TABLE IF EXISTS `small_business`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `small_business` (
  `SB_id` int(11) NOT NULL AUTO_INCREMENT,
  `User_id` int(11) DEFAULT NULL,
  `Name` varchar(450) DEFAULT NULL,
  `Area` int(11) DEFAULT NULL,
  `SB_average_mark` float DEFAULT NULL,
  `SB_votes` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  `Category` int(11) DEFAULT NULL,
  `Address` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`SB_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `activity_category`
--

DROP TABLE IF EXISTS `activity_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `activity_category` (
  `Category_id` int(11) NOT NULL AUTO_INCREMENT,
  `Category_name` varchar(45) DEFAULT NULL,
  `Category_description` mediumtext,
  `Status` int(11) DEFAULT NULL,
  `lng` varchar(45) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`Category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=233 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user_messages`
--

DROP TABLE IF EXISTS `user_messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_messages` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Origin` int(11) NOT NULL,
  `Destination` int(11) NOT NULL,
  `Message` text,
  `MRead` int(11) DEFAULT '0',
  `DateSent` datetime DEFAULT NULL,
  `DateRead` datetime DEFAULT NULL,
  `MReplied` int(11) DEFAULT '0',
  `idOffer` int(11) DEFAULT NULL,
  `idReq` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2986 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'life_2_0'
--

--
-- Dumping routines for database 'life_2_0'
--
/*!50003 DROP FUNCTION IF EXISTS `isInCtryCode` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `isInCtryCode`(x VARCHAR(800), delim varchar(12), countryCodeVal VARCHAR(200)) RETURNS int(11)
BEGIN

    Declare returnVal INTEGER;
    Declare Valcount INT(10);
    Declare v1 INT(10);
    Declare dbRegion VARCHAR(800);
    
    SET returnVal=0;
    
    SET Valcount = substrCount(x,delim)+1;    
    SET v1=0;
    
    WHILE (v1 <Valcount) DO
     SELECT country_code into dbRegion FROM  regions WHERE id=strSplit(x,delim,v1+1);
     
     IF dbRegion=countryCodeVal THEN
     RETURN 1;
     END IF;
    SET v1 = v1 + 1;
    END WHILE;
    
    RETURN returnVal;
    
    
    

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `isInRegion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `isInRegion`(x VARCHAR(800), delim varchar(12), regionVal VARCHAR(200)) RETURNS int(11)
BEGIN

    Declare returnVal INTEGER;
    Declare Valcount INT(10);
    Declare v1 INT(10);
    Declare dbRegion VARCHAR(800);
    
    SET returnVal=0;
    
    SET Valcount = substrCount(x,delim)+1;    
    SET v1=0;
    
    WHILE (v1 <Valcount) DO
     SELECT name into dbRegion FROM  regions WHERE id=strSplit(x,delim,v1+1);
     
     IF dbRegion=regionVal THEN
     RETURN 1;
     END IF;
    SET v1 = v1 + 1;
    END WHILE;
    
    RETURN returnVal;
    
    
    

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `isInSupraRegion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `isInSupraRegion`(x VARCHAR(800), delim varchar(12), supraRegionVal VARCHAR(200)) RETURNS int(11)
BEGIN

    Declare returnVal INTEGER;
    Declare Valcount INT(10);
    Declare v1 INT(10);
    Declare dbRegion VARCHAR(800);
    
    SET returnVal=0;
    
    SET Valcount = substrCount(x,delim)+1;    
    SET v1=0;
    
    WHILE (v1 <Valcount) DO
     SELECT supraRegion into dbRegion FROM  regions WHERE id=strSplit(x,delim,v1+1);
     
     IF dbRegion=supraRegionVal THEN
     RETURN 1;
     END IF;
    SET v1 = v1 + 1;
    END WHILE;
    
    RETURN returnVal;
    
    
    

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `strSplit` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `strSplit`(x varchar(255), delim varchar(12), pos int) RETURNS varchar(255) CHARSET latin1
BEGIN

return replace(substring(substring_index(x,delim,pos),length(substring_index(x,delim,pos-1))+1),delim,'');
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `substrCount` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `substrCount`(s VARCHAR(255), ss VARCHAR(255)) RETURNS tinyint(3) unsigned
    READS SQL DATA
BEGIN
DECLARE count TINYINT(3) UNSIGNED;
DECLARE offset TINYINT(3) UNSIGNED;
DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET s=NULL;

SET count=0;
SET offset=1;

REPEAT
IF NOT ISNULL(s) AND offset>0 THEN
SET offset=LOCATE(ss,s,offset);
IF offset>0 THEN
SET count=count+1;
SET offset=offset+1;
END IF;
END IF;
UNTIL ISNULL(s) OR offset=0 END REPEAT;

RETURN count;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `inc_offer_count` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `inc_offer_count`(
       IN pOfferId INTEGER,
       IN pLogin VARCHAR(45))
BEGIN

    DECLARE counter INTEGER;
    DECLARE hist VARCHAR(50000);
    DECLARE hist2 VARCHAR(50000);
    DECLARE sLogin VARCHAR(45);
    
    SET sLogin = CONCAT('.', pLogin, '.');

    SELECT Views,ViewsHist INTO counter, hist2
    FROM catalogue 
    WHERE Offer_id = pOfferId;
    
    IF hist2 IS NULL THEN
     SET hist = '';
    ELSE
     SET hist = CONCAT('', hist2);
    END IF;
    
    IF NOT INSTR(hist, sLogin) THEN

        SET counter = counter + 1;
        SET hist = CONCAT(hist, sLogin);

        UPDATE
            catalogue
        SET
            Views = counter,
            ViewsHist = hist
        WHERE
            Offer_id = pOfferId;

    END IF;
    
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-03-10 14:01:46
