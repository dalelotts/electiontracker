-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema electiontracker
--

CREATE DATABASE IF NOT EXISTS electiontracker;
USE electiontracker;

--
-- Definition of table `attributetype`
--

DROP TABLE IF EXISTS `attributetype`;
CREATE TABLE `attributetype` (
  `AttributeTypeID` int(10) unsigned NOT NULL auto_increment,
  `AttributeTypeName` varchar(100) NOT NULL,
  PRIMARY KEY  (`AttributeTypeID`),
  UNIQUE KEY `UNQ_AttributeTypeName` (`AttributeTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `attributetype`
--

/*!40000 ALTER TABLE `attributetype` DISABLE KEYS */;
/*!40000 ALTER TABLE `attributetype` ENABLE KEYS */;


--
-- Definition of table `candidate`
--

DROP TABLE IF EXISTS `candidate`;
CREATE TABLE `candidate` (
  `CandidateID` int(10) unsigned NOT NULL auto_increment,
  `CandidateFirstName` varchar(100) NOT NULL,
  `CandidateMiddleName` varchar(45) default NULL,
  `CandidateLastName` varchar(100) NOT NULL,
  `CandidatePoliticalPartyID` int(10) unsigned default NULL,
  `CandidateNotes` text,
  `CandidateIsActive` tinyint(1) default NULL,
  PRIMARY KEY  (`CandidateID`),
  KEY `FK_candidate_political_party` (`CandidatePoliticalPartyID`),
  CONSTRAINT `FK_candidate_political_party` FOREIGN KEY (`CandidatePoliticalPartyID`) REFERENCES `politicalparty` (`PoliticalPartyID`)
) ENGINE=InnoDB AUTO_INCREMENT=387 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `candidate`
--

/*!40000 ALTER TABLE `candidate` DISABLE KEYS */;
INSERT INTO `candidate` (`CandidateID`,`CandidateFirstName`,`CandidateMiddleName`,`CandidateLastName`,`CandidatePoliticalPartyID`,`CandidateNotes`,`CandidateIsActive`) VALUES 
 (314,'Ron',NULL,'Kind',1,NULL,1),
 (324,'Kitty',NULL,'Rhoades',2,NULL,1),
 (326,'Jeff',NULL,'Wood',2,NULL,1),
 (330,'Mary',NULL,'Hubler',1,NULL,1),
 (333,'Mary',NULL,'Williams',2,NULL,1),
 (334,'Barbara',NULL,'Gronemus',1,NULL,1),
 (335,'David',NULL,'Anderson',2,NULL,1),
 (337,'Terry',NULL,'Musser',2,NULL,1),
 (339,'Rob',NULL,'Kreibich',2,NULL,1),
 (341,'Mark',NULL,'Pettis',2,NULL,1),
 (344,'Jeff',NULL,'Smith',1,NULL,1),
 (349,'Curtis',NULL,'Miller',1,NULL,1),
 (350,'Dan',NULL,'Gorman',1,NULL,1),
 (351,'Dari',NULL,'McDonald',2,NULL,1),
 (352,'Dewey',NULL,'Floberg',1,NULL,1),
 (353,'John',NULL,'Murtha',2,NULL,1),
 (354,'Ann',NULL,'Hraychuck',1,NULL,1),
 (355,'Roberta',NULL,'Rasmus',1,NULL,1),
 (356,'Michael',NULL,'Turner',1,NULL,1),
 (360,'Scott',NULL,'Suder',2,NULL,1),
 (361,'Timothy',NULL,'Swiggum',1,NULL,1),
 (364,'Bob',NULL,'Jauch',1,NULL,1),
 (365,'Shirley',NULL,'Reidmann',2,NULL,1),
 (366,'Russ',NULL,'Decker',1,NULL,1),
 (367,'Jimmy Boy',NULL,'Edming',2,NULL,1),
 (368,'Dave',NULL,'Zien',2,NULL,1),
 (369,'Pat',NULL,'Kreitlow',1,NULL,1),
 (370,'Ron',NULL,'Brown',2,NULL,1),
 (371,'Kathleen',NULL,'Vinehout',1,NULL,1),
 (372,'Kerry',NULL,'Kittel',1,NULL,1),
 (373,'Paul',NULL,'Nelson',2,NULL,1),
 (375,'Jim',NULL,'Doyle',1,NULL,1),
 (376,'Mark',NULL,'Green',2,NULL,1),
 (377,'Nelson',NULL,'Eisman',4,NULL,1),
 (381,'Linda','M.','Clifford',NULL,NULL,1),
 (382,'Annette','K.','Ziegler',NULL,'',1),
 (386,'Terry',NULL,'Moulton',2,'',1);
/*!40000 ALTER TABLE `candidate` ENABLE KEYS */;


--
-- Definition of table `candidateresponse`
--

DROP TABLE IF EXISTS `candidateresponse`;
CREATE TABLE `candidateresponse` (
  `ResponseID` int(10) unsigned NOT NULL,
  `CandidateID` int(10) unsigned NOT NULL,
  PRIMARY KEY  USING BTREE (`ResponseID`),
  KEY `FK_candidateresponse_candidate` (`CandidateID`),
  CONSTRAINT `FK_candidateresponse_candidate` FOREIGN KEY (`CandidateID`) REFERENCES `candidate` (`CandidateID`),
  CONSTRAINT `FK_candidateresponse_response` FOREIGN KEY (`ResponseID`) REFERENCES `response` (`ResponseID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `candidateresponse`
--

/*!40000 ALTER TABLE `candidateresponse` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidateresponse` ENABLE KEYS */;


--
-- Definition of table `contest`
--

DROP TABLE IF EXISTS `contest`;
CREATE TABLE `contest` (
  `ContestID` int(10) unsigned NOT NULL auto_increment,
  `ContestName` varchar(100) NOT NULL,
  `ContestNotes` text,
  `ContestIsActive` tinyint(1) NOT NULL default '1',
  PRIMARY KEY  (`ContestID`),
  UNIQUE KEY `UNQ_ContestName` USING BTREE (`ContestName`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contest`
--

/*!40000 ALTER TABLE `contest` DISABLE KEYS */;
INSERT INTO `contest` (`ContestID`,`ContestName`,`ContestNotes`,`ContestIsActive`) VALUES 
 (22,'31st Senate',NULL,1),
 (23,'23rd Senate',NULL,1),
 (24,'28th Assembly',NULL,1),
 (25,'29th Assembly',NULL,1),
 (28,'92nd Assembly',NULL,1),
 (29,'93rd Assembly',NULL,1),
 (30,'30th Assembly',NULL,1),
 (31,'69th Assembly',NULL,1),
 (32,'3rd Congressional - Republicans',NULL,1),
 (33,'3rd Congressional',NULL,1),
 (34,'68th Assembly - Democrats',NULL,1),
 (37,'94th Assembly',NULL,1),
 (38,'95th Assembly',NULL,1),
 (39,'87th Assembly',NULL,1),
 (41,'Governor',NULL,1),
 (44,'67th Assembly - Democrats',NULL,1),
 (46,'10th Senate',NULL,1),
 (47,'75th Assembly',NULL,1),
 (50,'U.S. Senate',NULL,1),
 (51,'Attorney General',NULL,1),
 (64,'68th Assembly - Republicans',NULL,1),
 (65,'29th Assembly - Democrats',NULL,1),
 (71,'Sheriff - Eau Claire County',NULL,1),
 (73,'92nd Assembly - Republicans',NULL,1),
 (77,'96th Assembly',NULL,1),
 (83,'7th Congressional',NULL,1),
 (87,'87th Assembly - Democrats',NULL,1),
 (88,'87th Assembly - Republicans',NULL,1),
 (89,'67th Assembly',NULL,1),
 (90,'67th Assembly - Republicans',NULL,1),
 (92,'67 Assembly-Dem',NULL,1),
 (93,'29th Senate',NULL,1),
 (94,'91 Assembly',NULL,1),
 (101,'25th Senate',NULL,1),
 (104,'Supreme Court',NULL,1),
 (108,'President',NULL,1);
/*!40000 ALTER TABLE `contest` ENABLE KEYS */;


--
-- Definition of table `contestcounty`
--

DROP TABLE IF EXISTS `contestcounty`;
CREATE TABLE `contestcounty` (
  `ContestCountyID` int(10) unsigned NOT NULL auto_increment,
  `ElectionContestID` int(10) unsigned NOT NULL,
  `CountyID` int(10) unsigned NOT NULL,
  `WardCount` int(10) unsigned NOT NULL,
  `WardsReporting` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ContestCountyID`),
  KEY `CountyID` (`CountyID`),
  KEY `ElectionContestID` (`ElectionContestID`),
  CONSTRAINT `CountyID` FOREIGN KEY (`CountyID`) REFERENCES `county` (`CountyID`),
  CONSTRAINT `ElectionContestID` FOREIGN KEY (`ElectionContestID`) REFERENCES `electioncontest` (`ElectionContestID`)
) ENGINE=InnoDB AUTO_INCREMENT=368 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contestcounty`
--

/*!40000 ALTER TABLE `contestcounty` DISABLE KEYS */;
/*!40000 ALTER TABLE `contestcounty` ENABLE KEYS */;


--
-- Definition of table `county`
--

DROP TABLE IF EXISTS `county`;
CREATE TABLE `county` (
  `CountyID` int(10) unsigned NOT NULL auto_increment,
  `CountyName` varchar(255) NOT NULL,
  `CountyNotes` text,
  `CountyWardCount` int(10) unsigned default NULL,
  PRIMARY KEY  (`CountyID`),
  UNIQUE KEY `UNQ_CountyName` (`CountyName`),
  UNIQUE KEY `IDX_CountyName` USING BTREE (`CountyName`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `county`
--

/*!40000 ALTER TABLE `county` DISABLE KEYS */;
INSERT INTO `county` (`CountyID`,`CountyName`,`CountyNotes`,`CountyWardCount`) VALUES 
 (33,'Barron','715-537-6200,6201',10),
 (34,'Buffalo','Clerk',0),
 (35,'Burnett','715-349-2173',5),
 (36,'Chippewa','Day 726-7980',0),
 (37,'Eau Claire','839-4803 if needed',0),
 (41,'Clark','715-743-5150-night',0),
 (42,'Crawford','',0),
 (43,'Dunn','Use Explorer only',5),
 (44,'Grant','COUNTY CLERK',0),
 (45,'Jackson','day-715-284-0201',0),
 (46,'Lacrosse','day 608-785-9788',0),
 (47,'Marathon','day 715-261-1500',0),
 (48,'Monroe','COUNTY CLERK',0),
 (49,'Pepin','Paper ballots',5),
 (50,'Pierce','',0),
 (51,'Polk','715-485-9226 day/nt.',0),
 (52,'Price','Summary has ward ct.',5),
 (53,'Rusk','day 715-532-2100',0),
 (54,'St. Croix','715-386-4610,4607',0),
 (55,'Taylor','715-748-1461,1462',0),
 (56,'Trempealeau','must call',0),
 (57,'Vernon','day 608-637-5380',0),
 (80,'Washburn','Clerk',0),
 (85,'Sawyer','Day 715-634-4866',0),
 (97,'Wood',' day 715-421-8460',0),
 (101,'Shawano','day 715-526-9135',0);
/*!40000 ALTER TABLE `county` ENABLE KEYS */;


--
-- Definition of table `countyattribute`
--

DROP TABLE IF EXISTS `countyattribute`;
CREATE TABLE `countyattribute` (
  `CountyID` int(10) unsigned NOT NULL,
  `AttributeTypeID` int(10) unsigned NOT NULL,
  `CountyAttributeValue` varchar(100) NOT NULL,
  `CountyAttributeID` int(10) unsigned NOT NULL auto_increment,
  PRIMARY KEY  USING BTREE (`CountyAttributeID`),
  UNIQUE KEY `UNQ_County_Attribute` (`CountyID`,`AttributeTypeID`),
  KEY `FK_CountyAttribute_AttributeType` (`AttributeTypeID`),
  CONSTRAINT `FK_CountyAttribute_AttributeType` FOREIGN KEY (`AttributeTypeID`) REFERENCES `attributetype` (`AttributeTypeID`),
  CONSTRAINT `FK_CountyAttribute_County` FOREIGN KEY (`CountyID`) REFERENCES `county` (`CountyID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `countyattribute`
--

/*!40000 ALTER TABLE `countyattribute` DISABLE KEYS */;
/*!40000 ALTER TABLE `countyattribute` ENABLE KEYS */;


--
-- Definition of table `countyphonenumber`
--

DROP TABLE IF EXISTS `countyphonenumber`;
CREATE TABLE `countyphonenumber` (
  `CountyPhoneNumberID` int(10) unsigned NOT NULL auto_increment,
  `CountyID` int(10) unsigned NOT NULL,
  `PhoneNumberTypeID` int(10) unsigned NOT NULL,
  `PhoneNumberAreaCode` varchar(5) NOT NULL,
  `PhoneNumberNumber` varchar(10) NOT NULL,
  `PhoneNumberExtension` varchar(10) default NULL,
  PRIMARY KEY  (`CountyPhoneNumberID`),
  KEY `FK_countyphonenumber_county` (`CountyID`),
  KEY `FK_countyphonenumber_type` (`PhoneNumberTypeID`),
  CONSTRAINT `FK_countyphonenumber_county` FOREIGN KEY (`CountyID`) REFERENCES `county` (`CountyID`),
  CONSTRAINT `FK_countyphonenumber_type` FOREIGN KEY (`PhoneNumberTypeID`) REFERENCES `phonenumbertype` (`PhoneNumberTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `countyphonenumber`
--

/*!40000 ALTER TABLE `countyphonenumber` DISABLE KEYS */;
INSERT INTO `countyphonenumber` (`CountyPhoneNumberID`,`CountyID`,`PhoneNumberTypeID`,`PhoneNumberAreaCode`,`PhoneNumberNumber`,`PhoneNumberExtension`) VALUES 
 (1,101,3,'715','526-9135',NULL),
 (4,35,3,'715','349-2173',NULL),
 (5,36,3,'715','726-7983',NULL),
 (6,37,3,'715','839-4802',NULL),
 (7,41,3,'715','743-5148',NULL),
 (9,43,3,'715','232-1677',NULL),
 (10,44,3,'608','723-2675',NULL),
 (11,45,3,'715','284-0249',NULL),
 (12,46,3,'608','785-9581',NULL),
 (13,47,3,'715','261-1000',NULL),
 (14,48,3,'608','372-8705',NULL),
 (16,50,3,'715','273-3531',NULL),
 (17,51,3,'715','485-9223',NULL),
 (18,52,3,'715','339-3325',NULL),
 (19,53,3,'715','532-2100',NULL),
 (20,54,3,'715','386-4609',NULL),
 (21,55,3,'715','748-1460',NULL),
 (22,56,3,'715','538-2311',NULL),
 (23,57,3,'608','637-5304',NULL),
 (24,80,3,'715','468-4605',NULL),
 (25,85,3,'715','638-3245',NULL),
 (26,97,3,'715','421-8460',NULL),
 (35,33,3,'715','537-6200',NULL),
 (36,33,4,'715','537-6201',NULL);
/*!40000 ALTER TABLE `countyphonenumber` ENABLE KEYS */;


--
-- Definition of table `countywebsite`
--

DROP TABLE IF EXISTS `countywebsite`;
CREATE TABLE `countywebsite` (
  `CountyWebsiteID` int(10) unsigned NOT NULL auto_increment,
  `CountyID` int(10) unsigned NOT NULL,
  `CountyWebsiteURL` varchar(255) NOT NULL,
  PRIMARY KEY  (`CountyWebsiteID`),
  KEY `FK_countywebsite_county` (`CountyID`),
  CONSTRAINT `FK_countywebsite_county` FOREIGN KEY (`CountyID`) REFERENCES `county` (`CountyID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `countywebsite`
--

/*!40000 ALTER TABLE `countywebsite` DISABLE KEYS */;
INSERT INTO `countywebsite` (`CountyWebsiteID`,`CountyID`,`CountyWebsiteURL`) VALUES 
 (1,33,'www.co.barron.wi.us'),
 (2,35,'www.burnettcounty.com'),
 (3,36,'www.co.chippewa.wi.us'),
 (4,41,'www.co.clark.wi.us'),
 (6,43,'www.co.dunn.wi.us'),
 (7,45,'www.co.jackson.wi.us'),
 (8,46,'www.co.la-crosse.wi.us'),
 (9,47,'www.co.marathon.wi.us/election'),
 (10,48,'www.co.monroe.wi.us'),
 (11,50,'www.co.pierce.wi.us'),
 (12,51,'www.co.polk.wi.us'),
 (13,52,'www.co.price.wi.us'),
 (14,54,'www.co.saint-croix.wi.us'),
 (15,55,'www.co.taylor.wi.us'),
 (16,85,'www.sawyercountygov.org'),
 (17,97,'www.co.wood.wi.us'),
 (18,101,'www.co.shawano.wi.us');
/*!40000 ALTER TABLE `countywebsite` ENABLE KEYS */;


--
-- Definition of table `customresponse`
--

DROP TABLE IF EXISTS `customresponse`;
CREATE TABLE `customresponse` (
  `ResponseID` int(10) unsigned NOT NULL,
  `ResponseName` varchar(100) NOT NULL,
  PRIMARY KEY  (`ResponseID`),
  UNIQUE KEY `UNQ_CustomResponseName` (`ResponseID`,`ResponseName`),
  CONSTRAINT `FK_customresponse_response` FOREIGN KEY (`ResponseID`) REFERENCES `response` (`ResponseID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customresponse`
--

/*!40000 ALTER TABLE `customresponse` DISABLE KEYS */;
/*!40000 ALTER TABLE `customresponse` ENABLE KEYS */;


--
-- Definition of table `election`
--

DROP TABLE IF EXISTS `election`;
CREATE TABLE `election` (
  `ElectionID` int(10) unsigned NOT NULL auto_increment,
  `ElectionDate` date NOT NULL,
  `ElectionNotes` text NOT NULL,
  `ElectionIsActive` tinyint(1) NOT NULL,
  PRIMARY KEY  (`ElectionID`),
  UNIQUE KEY `UNQ_ElectionDate` USING BTREE (`ElectionDate`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=latin1 COMMENT='Election Table';

--
-- Dumping data for table `election`
--

/*!40000 ALTER TABLE `election` DISABLE KEYS */;
/*!40000 ALTER TABLE `election` ENABLE KEYS */;


--
-- Definition of table `electioncontest`
--

DROP TABLE IF EXISTS `electioncontest`;
CREATE TABLE `electioncontest` (
  `ElectionContestID` int(10) unsigned NOT NULL auto_increment,
  `ElectionID` int(10) unsigned NOT NULL,
  `ContestID` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`ElectionContestID`),
  UNIQUE KEY `UNQ_ElectionContest` (`ElectionID`,`ContestID`),
  KEY `ContestID` (`ContestID`),
  CONSTRAINT `ContestID` FOREIGN KEY (`ContestID`) REFERENCES `contest` (`ContestID`),
  CONSTRAINT `ElectionID` FOREIGN KEY (`ElectionID`) REFERENCES `election` (`ElectionID`)
) ENGINE=InnoDB AUTO_INCREMENT=143 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `electioncontest`
--

/*!40000 ALTER TABLE `electioncontest` DISABLE KEYS */;
/*!40000 ALTER TABLE `electioncontest` ENABLE KEYS */;


--
-- Definition of table `phonenumbertype`
--

DROP TABLE IF EXISTS `phonenumbertype`;
CREATE TABLE `phonenumbertype` (
  `PhoneNumberTypeID` int(10) unsigned NOT NULL auto_increment,
  `PhoneNumberTypeName` varchar(45) NOT NULL,
  PRIMARY KEY  (`PhoneNumberTypeID`),
  UNIQUE KEY `UNQ_PhoneNumberTypeName` (`PhoneNumberTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `phonenumbertype`
--

/*!40000 ALTER TABLE `phonenumbertype` DISABLE KEYS */;
INSERT INTO `phonenumbertype` (`PhoneNumberTypeID`,`PhoneNumberTypeName`) VALUES 
 (4,'Alternate'),
 (1,'Election Day'),
 (5,'Fax'),
 (3,'Main'),
 (2,'Mobile');
/*!40000 ALTER TABLE `phonenumbertype` ENABLE KEYS */;


--
-- Definition of table `politicalparty`
--

DROP TABLE IF EXISTS `politicalparty`;
CREATE TABLE `politicalparty` (
  `PoliticalPartyID` int(10) unsigned NOT NULL auto_increment,
  `PoliticalPartyName` varchar(100) NOT NULL,
  `PoliticalPartyAbbrev` varchar(5) NOT NULL,
  `PoliticalPartyIsActive` tinyint(1) NOT NULL,
  PRIMARY KEY  (`PoliticalPartyID`),
  UNIQUE KEY `UNQ_PoliticalPartyName` (`PoliticalPartyName`),
  UNIQUE KEY `UNQ_PoliticalPartyAbbrev` (`PoliticalPartyAbbrev`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `politicalparty`
--

/*!40000 ALTER TABLE `politicalparty` DISABLE KEYS */;
INSERT INTO `politicalparty` (`PoliticalPartyID`,`PoliticalPartyName`,`PoliticalPartyAbbrev`,`PoliticalPartyIsActive`) VALUES 
 (1,'Democrat','D',1),
 (2,'Republican','R',1),
 (3,'Independent','Ind.',1),
 (4,'Green','Gr',1);
/*!40000 ALTER TABLE `politicalparty` ENABLE KEYS */;


--
-- Definition of table `response`
--

DROP TABLE IF EXISTS `response`;
CREATE TABLE `response` (
  `ResponseID` int(10) unsigned NOT NULL auto_increment,
  `ElectionContestID` int(10) unsigned NOT NULL,
  `SortOrder` int(10) unsigned NOT NULL default '0',
  `Incumbent` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  USING BTREE (`ResponseID`),
  KEY `FK_response_ElectionContest` (`ElectionContestID`),
  CONSTRAINT `FK_response_ElectionContest` FOREIGN KEY (`ElectionContestID`) REFERENCES `electioncontest` (`ElectionContestID`)
) ENGINE=InnoDB AUTO_INCREMENT=388 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `response`
--

/*!40000 ALTER TABLE `response` DISABLE KEYS */;
/*!40000 ALTER TABLE `response` ENABLE KEYS */;


--
-- Definition of table `responsevalue`
--

DROP TABLE IF EXISTS `responsevalue`;
CREATE TABLE `responsevalue` (
  `ResponseValueID` int(10) unsigned NOT NULL auto_increment,
  `ResponseID` int(10) unsigned NOT NULL,
  `ContestCountyID` int(10) unsigned NOT NULL,
  `VoteCount` int(10) unsigned NOT NULL,
  PRIMARY KEY  USING BTREE (`ResponseValueID`),
  KEY `FK_responsevalue_response` (`ResponseID`),
  KEY `FK_responsevalue_contestcounty` (`ContestCountyID`),
  CONSTRAINT `FK_responsevalue_contestcounty` FOREIGN KEY (`ContestCountyID`) REFERENCES `contestcounty` (`ContestCountyID`),
  CONSTRAINT `FK_responsevalue_response` FOREIGN KEY (`ResponseID`) REFERENCES `response` (`ResponseID`)
) ENGINE=InnoDB AUTO_INCREMENT=360 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `responsevalue`
--

/*!40000 ALTER TABLE `responsevalue` DISABLE KEYS */;
/*!40000 ALTER TABLE `responsevalue` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
