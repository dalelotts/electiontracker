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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=388 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `candidate`
--

/*!40000 ALTER TABLE `candidate` DISABLE KEYS */;

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
  `ContestIsFinal` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`ContestID`),
  UNIQUE KEY `UNQ_ContestName` USING BTREE (`ContestName`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contest`
--

/*!40000 ALTER TABLE `contest` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=407 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `county`
--

/*!40000 ALTER TABLE `county` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `countyphonenumber`
--

/*!40000 ALTER TABLE `countyphonenumber` DISABLE KEYS */;
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
  `ElectionNotes` text,
  `ElectionIsActive` tinyint(1) NOT NULL,
  PRIMARY KEY  (`ElectionID`),
  UNIQUE KEY `UNQ_ElectionDate` USING BTREE (`ElectionDate`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COMMENT='Election Table';

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
) ENGINE=InnoDB AUTO_INCREMENT=149 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `politicalparty`
--

/*!40000 ALTER TABLE `politicalparty` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=400 DEFAULT CHARSET=latin1;

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
-- Definition of table 'defaultcontestcounty'
--
DROP TABLE IF EXISTS `electiontracker`.`defaultcontestcounty`;
CREATE TABLE  `electiontracker`.`defaultcontestcounty` (
  `DefaultContestCountyID` int(10) unsigned NOT NULL auto_increment,
  `ContestID` int(10) unsigned NOT NULL,
  `CountyID` int(10) unsigned NOT NULL,
  `WardCount` int(10) unsigned NOT NULL,
  `WardsReporting` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`DefaultContestCountyID`),
  KEY `FK_defaultcontestcounty_ContestKey` (`ContestID`),
  KEY `FK_defaultcontestcounty_countykey` (`CountyID`),
  CONSTRAINT `FK_defaultcontestcounty_ContestKey` FOREIGN KEY (`ContestID`) REFERENCES `contest` (`ContestID`),
  CONSTRAINT `FK_defaultcontestcounty_countykey` FOREIGN KEY (`CountyID`) REFERENCES `county` (`CountyID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

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