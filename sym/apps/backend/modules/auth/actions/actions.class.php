<?php

/**
 * auth actions.
 *
 * @package    feelwine
 * @subpackage auth
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class authActions extends sfActions
{
 /**
  * Executes index action
  *
  * @param sfRequest $request A request object
  */
  public function executeIndex(sfWebRequest $request)
  {
    $this->forward('default', 'module');
  }
  
  public function executeSignout(sfWebRequest $request)
  {
    //$this->getUser()->getAttributeHolder()->remove('admin_module');
    $this->getUser()->getAttributeHolder()->clear();
    $this->redirect('sf_guard_signout');
  }
  
}
