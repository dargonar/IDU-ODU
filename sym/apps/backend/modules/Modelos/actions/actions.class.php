<?php

require_once dirname(__FILE__).'/../lib/ModelosGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/ModelosGeneratorHelper.class.php';

/**
 * Modelos actions.
 *
 * @package    sf_sandbox
 * @subpackage Modelos
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class ModelosActions extends autoModelosActions
{
  public function executeIndex(sfWebRequest $request)
  {
  
    // if ($this->getUser()->getGuardUser()->getUsername()!='admin')
    // {
      $filters = $this->getUser()->getAttribute('Modelos.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['es_activo'] = array('text'=>'1');
      $this->setFilters($filters);
    // }
    return parent::executeIndex($request);
  }
  
  public function executeListReferencia(sfWebRequest $request)
  {  
    // modelos.modelos_referencia = caracteristicastecnicasequipos.caracteristicastecnicasequipos_nombre
    // caracteristicastecnicasequipos.caracteristicastecnicasequipos_idparametros = parametrosensayosidu.Parametrosensayosidu_id
    
    $modelo = $this->getRoute()->getObject();
    
    $obj = CaracteristicastecnicasequiposQuery::create_new()->getByNombre($modelo->getModelosReferencia(), $modelo->getModelosEsidu());
    
    $filters = $this->getUser()->getAttribute('caract_tecnicas.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    $filters['id'] = array('text'=>$obj->getId());
    //$this->setFilters($filters);
    $this->getUser()->setAttribute('caract_tecnicas.filters', $filters, 'admin_module');
    $this->redirect("@caracteristicastecnicasequipos");
    
  }
  
  protected function processForm(sfWebRequest $request, sfForm $form)
  {
    $values                       = $request->getParameter($form->getName());
    $caract_tecnica_id            = $values['modelos_referencia'];
    $caract_tecnica               = CaracteristicastecnicasequiposQuery::create_new()->getById($caract_tecnica_id);
    $values['modelos_referencia'] = $caract_tecnica->getCaracteristicastecnicasequiposNombre();
    
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
