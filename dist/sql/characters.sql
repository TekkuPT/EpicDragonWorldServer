CREATE TABLE IF NOT EXISTS `characters` (
  `account` varchar(20) DEFAULT NULL,
  `name` varchar(12) DEFAULT NULL,
  `slot` int(2) DEFAULT NULL,
  `class_id` int(2) DEFAULT NULL,
  `x` int(8) DEFAULT NULL,
  `y` int(8) DEFAULT NULL,
  `z` int(8) DEFAULT NULL,
  `heading` int(4) DEFAULT NULL,
  `experience` int(8) DEFAULT NULL,
  `hp` int(8) DEFAULT NULL,
  `mp` int(8) DEFAULT NULL,
  `access_level` int(2) DEFAULT NULL,
  `item_head` int(4) DEFAULT NULL,
  `item_chest` int(4) DEFAULT NULL,
  `item_gloves` int(4) DEFAULT NULL,
  `item_legs` int(4) DEFAULT NULL,
  `item_boots` int(4) DEFAULT NULL,
  `item_right_hand` int(4) DEFAULT NULL,
  `item_left_hand` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
