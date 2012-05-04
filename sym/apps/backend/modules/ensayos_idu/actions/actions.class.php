<?php

require_once dirname(__FILE__).'/../lib/ensayos_iduGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/ensayos_iduGeneratorHelper.class.php';

/**
 * ensayos_idu actions.
 *
 * @package    sf_sandbox
 * @subpackage ensayos_idu
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class ensayos_iduActions extends autoEnsayos_iduActions
{

  protected $config = array(
    "ensayosrealizadosidu_velocidadinicial"=>0.1,
    "ensayosrealizadosidu_velocidadbajatension"=>0.1,
    "ensayosrealizadosidu_velocidadlow"=>0.1,
    "ensayosrealizadosidu_velocidadhigh"=>0.1,
    "ensayosrealizadosidu_corrienteinicial"=>0.01,
    "ensayosrealizadosidu_corrientecalorinicial"=>0.01,
    "ensayosrealizadosidu_corrientebajatension"=>0.01,
    "ensayosrealizadosidu_corrientelow"=>0.01,
    "ensayosrealizadosidu_corrientehigh"=>0.01,
    );

  public function executeEdit(sfWebRequest $request)
  {
    $this->ensayosrealizadosidu = $this->getRoute()->getObject();
    
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value                          = $this->ensayosrealizadosidu->$attr * $this->config[$attr];
      $this->ensayosrealizadosidu->$attr  = (double)$new_value; 
    }
    $this->form = $this->configuration->getForm($this->ensayosrealizadosidu);
  }

  protected function processForm(sfWebRequest $request, sfForm $form)
  {
    $values = $request->getParameter($form->getName());
    
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value      = $values[$attr] / $this->config[$attr];
      $values[$attr]  = $new_value; 
    }
    
    $form->bind($values, null);
    
    
    if ($form->isValid())
    {
      $notice = $form->getObject()->isNew() ? 'The item was created successfully.' : 'The item was updated successfully.';

      try {
        $ensayosrealizadosidu = $form->save();
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

      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $ensayosrealizadosidu)));

      /*if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@ensayosrealizadosidu_new');
      }
      else
      {*/
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'ensayosrealizadosidu_edit', 'sf_subject' => $ensayosrealizadosidu));
      /*}*/
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }
  
}
