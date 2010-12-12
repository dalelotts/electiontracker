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