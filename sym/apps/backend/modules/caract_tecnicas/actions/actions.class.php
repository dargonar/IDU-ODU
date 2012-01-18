<?php

require_once dirname(__FILE__).'/../lib/caract_tecnicasGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/caract_tecnicasGeneratorHelper.class.php';

/**
 * caract_tecnicas actions.
 *
 * @package    sf_sandbox
 * @subpackage caract_tecnicas
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class caract_tecnicasActions extends autoCaract_tecnicasActions
{
  public function executeIndex(sfWebRequest $request)
  {
  
    // if ($this->getUser()->getGuardUser()->getUsername()!='admin')
    // {
      $filters = $this->getUser()->getAttribute('caract_tecnicas.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['es_activo'] = array('text'=>'1');
      $this->setFilters($filters);
    // }
    return parent::executeIndex($request);
  }
  
  public function executeListParametros(sfWebRequest $request)
  {  
    // modelos.modelos_referencia = caracteristicastecnicasequipos.caracteristicastecnicasequipos_nombre
    // caracteristicastecnicasequipos.caracteristicastecnicasequipos_idparametros = parametrosensayosidu.Parametrosensayosidu_id
    
    $caract_id  = $request->getParameter('caracteristicastecnicasequipos_id',null);//$this->getRoute()->getObject();
    $caract     = CaracteristicastecnicasequiposQuery::create_new()->getById($caract_id);
    
    $obj        = ParametrosensayosQuery::create_new()->getById($caract->getCaracteristicastecnicasequiposIdparametros()
                                                          , $caract->getCaracteristicastecnicasequiposEsidu());
    if($caract->getCaracteristicastecnicasequiposEsidu()==1)
    {
      $filters = $this->getUser()->getAttribute('parametros_idu.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['parametrosensayosidu_id'] = array('text'=>$obj->getParametrosensayosiduId());
      $this->getUser()->setAttribute('parametros_idu.filters', $filters, 'admin_module');
      $this->redirect("@parametrosensayosidu");
    }
    else
    {
      $filters = $this->getUser()->getAttribute('parametros_odu.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['parametrosensayosodu_id'] = array('text'=>$obj->getParametrosensayosoduId());
      $this->getUser()->setAttribute('parametros_odu.filters', $filters, 'admin_module');
      $this->redirect("@parametrosensayosodu");
    }
  }
  
  protected function processForm(sfWebRequest $request, sfForm $form)
  {
    $values                       = $request->getParameter($form->getName());
    $es_idu                       = $values['caracteristicastecnicasequipos_esidu'];
    
    if($es_idu==1 || $es_idu=='1')
    {  
      $values['caracteristicastecnicasequipos_idparametros'] = $values['caracteristicastecnicasequipos_idparametros_idu'];
    }
    else
    {
      $values['caracteristicastecnicasequipos_idparametros'] = $values['caracteristicastecnicasequipos_idparametros_odu'];
    }
    
    $form->bind($values, $request->getFiles($form->getName()));
    //$form->bind($request->getParameter($form->getName()), $request->getFiles($form->getName()));
    
    if ($form->isValid())
    {
      $notice = $form->getObject()->isNew() ? 'The item was created successfully.' : 'The item was updated successfully.';

      try {
        $modelos = $form->save();
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

      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $modelos)));

      if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@modelos_new');
      }
      else
      {
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'modelos_edit', 'sf_subject' => $modelos));
      }
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }
  
}
