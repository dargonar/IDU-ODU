<?php

require_once dirname(__FILE__).'/../lib/user_profileGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/user_profileGeneratorHelper.class.php';

/**
 * user_profile actions.
 *
 * @package    sf_sandbox
 * @subpackage user_profile
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class user_profileActions extends autoUser_profileActions
{

  public function executeListChangePassword(sfWebRequest $request)
  {
    $user = $this->getRoute()->getObject()->getUser();
    
    $user->password = $request->getParameter('newpass');
    $user->save();
  
    return $this->renderText("OK");
  }

  public function processForm(sfWebRequest $request, sfForm $form)
  {
    $form->bind($request->getParameter($form->getName()), $request->getFiles($form->getName()));
    
    if ($form->isValid())
    {
      $notice = $form->getObject()->isNew() ? 'The item was created successfully.' : 'The item was updated successfully.';

      $user_profile = null;
      try {
        $user_profile = $form->save();
      } catch (Doctrine_Validator_Exception $e) {
        
        $errorStack = $form->getObject()->getErrorStack();

        $message = get_class($form->getObject()) . ' has ' . count($errorStack) . " field" . (count($errorStack) > 1 ?  's' : null) . " with validation errors: ";
        foreach ($errorStack as $field => $errors) {
            $message .= "$field (" . implode(", ", $errors) . "), ";
        }
        $message = trim($message, ', ');

        $this->getUser()->setFlash('error', $message);
        return sfView::SUCCESS;
      }
      
      //HACKO
      $group_id = $form['sf_guard_user']['groups_list']->getValue();
      $user_id  = $user_profile->getSfGuardUserId();
      UserProfileQuery::create_new()->setUserGroup($user_id, $group_id);
      
      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $user_profile)));

      if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@user_profile_new');
      }
      else
      {
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'user_profile_edit', 'sf_subject' => $user_profile));
      }
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }

}
