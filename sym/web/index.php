<?php


require_once(dirname(__FILE__).'/../config/ProjectConfiguration.class.php');

//$configuration = ProjectConfiguration::getApplicationConfiguration('frontend', 'prod', false);
$configuration = ProjectConfiguration::getApplicationConfiguration('backend', 'prod', false);
sfContext::createInstance($configuration)->dispatch();
