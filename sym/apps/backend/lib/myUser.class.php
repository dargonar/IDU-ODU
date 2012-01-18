<?php

class myUser extends sfGuardSecurityUser
{

	public function logout()
	{    
		$this->getAttributeHolder()->clear();
		$this->setAuthenticated(false);
        
	}



}
