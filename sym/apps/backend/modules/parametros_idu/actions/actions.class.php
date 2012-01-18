<?php

require_once dirname(__FILE__).'/../lib/parametros_iduGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/parametros_iduGeneratorHelper.class.php';

/**
 * parametros_idu actions.
 *
 * @package    sf_sandbox
 * @subpackage parametros_idu
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class parametros_iduActions extends autoParametros_iduActions
{
  public function executeIndex(sfWebRequest $request)
  {
  
    // if ($this->getUser()->getGuardUser()->getUsername()!='admin')
    // {
      $filters = $this->getUser()->getAttribute('parametros_idu.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['es_activo'] = array('text'=>'1');
      $this->setFilters($filters);
    // }
    return parent::executeIndex($request);
  }
  
  
  protected $config = array(
    "parametrosensayosidu_retardostopinicial"=>0.1,
    "parametrosensayosidu_retardostartmitad"=>0.1,
    "parametrosensayosidu_timeoutcalor"=>0.1,
    "parametrosensayosidu_timeoutfrio"=>0.1,
    "parametrosensayosidu_retardostart2bajatension"=>0.1,
    "parametrosensayosidu_tiempomodovelocidadbaja"=>0.1,
    "parametrosensayosidu_tiempomodovelocidadalta"=>0.1,
    "parametrosensayosidu_retardodesenergizado"=>0.1,
    "parametrosensayosidu_final"=>0.1,
    "parametrosensayosidu_temperatura"=>0.1,
    "parametrosensayosidu_velocidadbajatensionmin"=>0.1,
    "parametrosensayosidu_corrientebajatensionmin"=>0.1,
    "parametrosensayosidu_velocidadminmodovelbaja"=>0.1,
    "parametrosensayosidu_corrienteminmodovelbaja"=>0.1,
    "parametrosensayosidu_velocidadminmodovelalta"=>0.1,
    "parametrosensayosidu_corrienteminmodovelalta"=>0.1,
    "parametrosensayosidu_velocidadbajatensionmax"=>0.1,
    "parametrosensayosidu_corrientebajatensionmax"=>0.1,
    "parametrosensayosidu_velocidadmaxmodovelbaja"=>0.1,
    "parametrosensayosidu_corrientemaxmodovelbaja"=>0.1,
    "parametrosensayosidu_velocidadmaxmodovelalta"=>0.1,
    "parametrosensayosidu_corrientemaxmodovelalta"=>0.1,
    "parametrosensayosidu_timeoutbajatension"=>0.1);



  public function executeEdit(sfWebRequest $request)
  {
    $this->parametrosensayosidu = $this->getRoute()->getObject();
    
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value                          = $this->parametrosensayosidu->$attr * $this->config[$attr];
      $this->parametrosensayosidu->$attr  = (int)$new_value; 
    }
    $this->form = $this->configuration->getForm($this->parametrosensayosidu);
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
        $parametrosensayosidu = $form->save();
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

      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $parametrosensayosidu)));

      if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@parametrosensayosidu_new');
      }
      else
      {
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'parametrosensayosidu_edit', 'sf_subject' => $parametrosensayosidu));
      }
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }
}
