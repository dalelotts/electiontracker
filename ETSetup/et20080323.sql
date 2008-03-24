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
INSERT INTO `attributetype` (`AttributeTypeID`,`AttributeTypeName`) VALUES 
 (7,'Election Day Contact');
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
 (337,'Terry',NULL,'Musser',2,NULL,0),
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
INSERT INTO `candidateresponse` (`ResponseID`,`CandidateID`) VALUES 
 (299,314),
 (365,314),
 (296,324),
 (378,324),
 (302,326),
 (331,326),
 (341,326),
 (350,326),
 (385,326),
 (307,330),
 (363,330),
 (310,333),
 (330,333),
 (346,333),
 (384,333),
 (311,334),
 (320,334),
 (337,334),
 (343,334),
 (361,334),
 (260,335),
 (312,335),
 (321,335),
 (329,335),
 (351,335),
 (314,337),
 (373,337),
 (315,339),
 (367,339),
 (292,341),
 (375,341),
 (316,344),
 (332,344),
 (335,344),
 (379,344),
 (313,349),
 (370,349),
 (265,350),
 (295,350),
 (336,350),
 (359,350),
 (308,351),
 (369,351),
 (264,352),
 (309,352),
 (328,352),
 (344,352),
 (358,352),
 (294,353),
 (372,353),
 (291,354),
 (362,354),
 (301,355),
 (334,355),
 (376,355),
 (338,356),
 (340,356),
 (382,356),
 (305,360),
 (380,360),
 (306,361),
 (333,361),
 (345,361),
 (381,361),
 (289,364),
 (364,364),
 (290,365),
 (377,365),
 (287,366),
 (324,366),
 (354,366),
 (262,367),
 (288,367),
 (326,367),
 (356,367),
 (387,368),
 (285,369),
 (368,369),
 (251,370),
 (298,370),
 (322,370),
 (352,370),
 (297,371),
 (339,371),
 (349,371),
 (383,371),
 (293,372),
 (366,372),
 (300,373),
 (374,373),
 (261,375),
 (317,375),
 (319,375),
 (325,375),
 (347,375),
 (355,375),
 (318,376),
 (348,376),
 (360,376),
 (263,377),
 (327,377),
 (342,377),
 (357,377),
 (258,381),
 (323,381),
 (353,381),
 (386,382),
 (371,386);
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
 (34,'68th Assembly - Democrats','Notes',1),
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
INSERT INTO `contestcounty` (`ContestCountyID`,`ElectionContestID`,`CountyID`,`WardCount`,`WardsReporting`) VALUES 
 (282,87,34,3,2),
 (283,87,33,4,2),
 (284,87,36,6,10),
 (293,92,33,5,4),
 (294,125,36,38,1),
 (295,125,33,5,0),
 (296,125,41,59,59),
 (297,125,43,20,20),
 (298,125,37,26,0),
 (299,125,47,17,0),
 (300,125,55,1,0),
 (301,125,97,0,0),
 (302,127,35,15,15),
 (303,127,51,32,32),
 (304,127,54,2,2),
 (305,128,43,10,10),
 (306,128,50,4,0),
 (307,128,54,0,28),
 (308,129,50,12,0),
 (309,129,54,0,7),
 (310,130,34,23,22),
 (311,130,41,2,2),
 (312,130,43,5,5),
 (313,130,37,31,0),
 (314,130,45,27,0),
 (315,130,48,19,0),
 (316,130,49,11,0),
 (317,130,50,12,0),
 (318,130,56,0,0),
 (319,94,43,5,5),
 (320,94,42,9,8),
 (321,94,41,57,57),
 (322,94,36,10,3),
 (323,94,35,5,3),
 (324,94,34,13,7),
 (325,94,33,10,10),
 (326,126,33,10,0),
 (327,126,34,0,0),
 (328,126,35,5,0),
 (329,126,36,0,0),
 (330,103,43,5,5),
 (331,105,44,42,16),
 (332,98,36,142,1),
 (333,95,34,16,19),
 (334,95,43,5,1),
 (335,101,37,78,13),
 (336,93,33,10,10),
 (337,99,41,33,9),
 (338,100,43,5,3),
 (339,96,41,19,3),
 (340,96,43,5,2),
 (341,102,43,5,4),
 (342,141,33,10,0),
 (343,141,34,0,0),
 (344,141,35,5,0),
 (345,141,36,0,0),
 (346,141,41,0,0),
 (347,141,42,0,0),
 (348,141,43,5,0),
 (349,141,37,0,0),
 (350,141,44,0,0),
 (351,141,45,0,0),
 (352,141,46,0,0),
 (353,141,47,0,0),
 (354,141,48,0,0),
 (355,141,49,5,0),
 (356,141,50,0,0),
 (357,141,51,0,0),
 (358,141,52,5,0),
 (359,141,53,0,0),
 (360,141,85,0,0),
 (361,141,101,0,0),
 (362,141,54,0,0),
 (363,141,55,0,0),
 (364,141,56,0,0),
 (365,141,57,0,0),
 (366,141,80,0,0),
 (367,141,97,0,0);
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
INSERT INTO `countyattribute` (`CountyID`,`AttributeTypeID`,`CountyAttributeValue`,`CountyAttributeID`) VALUES 
 (33,7,'Test Value',1);
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
INSERT INTO `election` (`ElectionID`,`ElectionDate`,`ElectionNotes`,`ElectionIsActive`) VALUES 
 (68,'2008-11-11','',1),
 (71,'2006-11-14','',1);
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
INSERT INTO `electioncontest` (`ElectionContestID`,`ElectionID`,`ContestID`) VALUES 
 (87,68,24),
 (92,68,25),
 (103,68,28),
 (105,68,29),
 (94,68,30),
 (98,68,31),
 (95,68,33),
 (101,68,39),
 (93,68,46),
 (99,68,47),
 (100,68,83),
 (96,68,89),
 (102,68,94),
 (130,71,22),
 (125,71,23),
 (127,71,24),
 (128,71,25),
 (139,71,28),
 (140,71,29),
 (129,71,30),
 (134,71,31),
 (131,71,33),
 (137,71,39),
 (141,71,41),
 (135,71,47),
 (136,71,83),
 (132,71,89),
 (142,71,93),
 (138,71,94),
 (126,71,101);
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
 (4,'Green','Gr',1),
 (9,'Socialist','Soc',1);
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
INSERT INTO `response` (`ResponseID`,`ElectionContestID`,`SortOrder`,`Incumbent`) VALUES 
 (251,87,0,0),
 (258,87,1,1),
 (260,92,0,1),
 (261,92,1,0),
 (262,92,2,0),
 (263,92,3,0),
 (264,92,4,0),
 (265,92,5,0),
 (285,125,0,1),
 (287,142,0,0),
 (288,142,1,0),
 (289,126,0,0),
 (290,126,1,0),
 (291,127,0,0),
 (292,127,1,0),
 (293,128,0,0),
 (294,128,1,0),
 (295,129,0,0),
 (296,129,1,0),
 (297,130,0,0),
 (298,130,1,0),
 (299,131,0,0),
 (300,131,1,0),
 (301,132,0,0),
 (302,132,1,0),
 (305,134,0,0),
 (306,134,1,0),
 (307,135,0,0),
 (308,135,1,0),
 (309,137,0,0),
 (310,137,1,0),
 (311,138,0,0),
 (312,138,1,0),
 (313,139,0,0),
 (314,139,1,0),
 (315,140,0,0),
 (316,140,1,0),
 (317,141,0,0),
 (318,141,1,0),
 (319,93,0,1),
 (320,93,1,0),
 (321,94,0,1),
 (322,94,1,0),
 (323,94,2,0),
 (324,94,3,0),
 (325,94,4,0),
 (326,94,5,0),
 (327,94,6,0),
 (328,94,7,0),
 (329,125,1,0),
 (330,136,0,0),
 (331,136,1,0),
 (332,103,0,1),
 (333,103,1,0),
 (334,105,0,0),
 (335,105,1,1),
 (336,98,0,0),
 (337,98,1,1),
 (338,95,0,1),
 (339,95,1,0),
 (340,101,0,0),
 (341,101,1,1),
 (342,99,0,0),
 (343,99,1,1),
 (344,100,0,0),
 (345,100,1,0),
 (346,100,2,1),
 (347,96,0,0),
 (348,96,1,1),
 (349,102,0,1),
 (350,102,1,0),
 (351,141,2,0),
 (352,141,3,0),
 (353,141,4,0),
 (354,141,5,0),
 (355,141,6,0),
 (356,141,7,0),
 (357,141,8,0),
 (358,141,9,0),
 (359,141,10,0),
 (360,141,11,0),
 (361,141,12,0),
 (362,141,13,0),
 (363,141,14,0),
 (364,141,15,0),
 (365,141,16,0),
 (366,141,17,0),
 (367,141,18,0),
 (368,141,19,0),
 (369,141,20,0),
 (370,141,21,0),
 (371,141,22,0),
 (372,141,23,0),
 (373,141,24,0),
 (374,141,25,0),
 (375,141,26,0),
 (376,141,27,0),
 (377,141,28,0),
 (378,141,29,0),
 (379,141,30,0),
 (380,141,31,0),
 (381,141,32,0),
 (382,141,33,0),
 (383,141,34,0),
 (384,141,35,0),
 (385,141,36,0),
 (386,141,37,0),
 (387,141,38,0);
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
INSERT INTO `responsevalue` (`ResponseValueID`,`ResponseID`,`ContestCountyID`,`VoteCount`) VALUES 
 (267,319,336,5),
 (268,320,336,1),
 (269,260,293,5),
 (270,261,293,10),
 (271,262,293,15),
 (272,263,293,20),
 (273,264,293,25),
 (274,265,293,30),
 (275,251,283,2),
 (276,258,283,3),
 (277,321,321,900),
 (278,322,321,600),
 (279,323,321,300),
 (280,324,321,42),
 (281,325,321,333),
 (282,326,321,71),
 (283,327,321,2),
 (284,328,321,600),
 (285,321,324,2),
 (286,322,324,4),
 (287,323,324,6),
 (288,324,324,8),
 (289,325,324,10),
 (290,326,324,12),
 (291,327,324,14),
 (292,328,324,16),
 (293,321,322,5),
 (294,322,322,10),
 (295,323,322,7),
 (296,324,322,59),
 (297,325,322,5),
 (298,326,322,3),
 (299,327,322,1),
 (300,328,322,0),
 (301,340,335,4),
 (302,341,335,2),
 (303,321,325,35),
 (304,322,325,40),
 (305,323,325,45),
 (306,324,325,50),
 (307,325,325,55),
 (308,326,325,60),
 (309,327,325,65),
 (310,328,325,70),
 (311,251,282,1),
 (312,258,282,2),
 (313,338,333,99),
 (314,339,333,500),
 (315,321,323,599),
 (316,322,323,42),
 (317,323,323,2),
 (318,324,323,95),
 (319,325,323,43),
 (320,326,323,9999),
 (321,327,323,428),
 (322,328,323,777),
 (323,251,284,5),
 (324,258,284,19),
 (325,336,332,55),
 (326,337,332,9),
 (327,347,339,55),
 (328,348,339,55),
 (329,342,337,33),
 (330,343,337,15),
 (331,321,320,5),
 (332,322,320,5),
 (333,323,320,48),
 (334,324,320,19),
 (335,325,320,3),
 (336,326,320,75),
 (337,327,320,4),
 (338,328,320,22),
 (339,321,319,1),
 (340,322,319,2),
 (341,323,319,2),
 (342,324,319,2),
 (343,325,319,2),
 (344,326,319,5),
 (345,327,319,19),
 (346,328,319,75),
 (347,338,334,19),
 (348,339,334,22),
 (349,347,340,3),
 (350,348,340,7),
 (351,344,338,6),
 (352,345,338,9),
 (353,346,338,12),
 (354,349,341,8),
 (355,350,341,16),
 (356,332,330,10),
 (357,333,330,20),
 (358,334,331,64),
 (359,335,331,32);
/*!40000 ALTER TABLE `responsevalue` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
