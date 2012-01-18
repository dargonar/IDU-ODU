<?php

require_once dirname(__FILE__).'/../lib/parametros_oduGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/parametros_oduGeneratorHelper.class.php';

/**
 * parametros_odu actions.
 *
 * @package    sf_sandbox
 * @subpackage parametros_odu
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class parametros_oduActions extends autoParametros_oduActions
{
  public function executeIndex(sfWebRequest $request)
  {
  
    // if ($this->getUser()->getGuardUser()->getUsername()!='admin')
    // {
      $filters = $this->getUser()->getAttribute('parametros_odu.filters', $this->configuration->getFilterDefaults(), 'admin_module');
      $filters['es_activo'] = array('text'=>'1');
      $this->setFilters($filters);
    // }
    return parent::executeIndex($request);
  }

  protected $config = array(
    "parametrosensayosodu_tiempoinicialestabilizacion"=>0.1,
    "parametrosensayosodu_tiempomaximoestabilizacion"=>0.1,
    "parametrosensayosodu_tiempobajatension"=>0.1,
    "parametrosensayosodu_tiempomaximobajatension"=>0.1,
    "parametrosensayosodu_tiempomedicioncalor"=>0.1,
    "parametrosensayosodu_tiempomaximomedicioncalor"=>0.1,
    "parametrosensayosodu_tiempomedicionfrio"=>0.1,
    "parametrosensayosodu_tiemporecuperacionminima"=>0.1,
    "parametrosensayosodu_tiempomaximorecuperacionminima"=>0.1,
    "parametrosensayosodu_delayarranquecompresor"=>0.1,
    "parametrosensayosodu_tiempoapagadoentrecaloryfrio"=>0.1,
    "parametrosensayosodu_tiempocierrevalvula1"=>0.1,
    "parametrosensayosodu_tiempocierrevalvula2"=>0.1,
    "parametrosensayosodu_tiempofinal"=>0.1,
    "parametrosensayosodu_presioninicialmin"=>0.01,
    "parametrosensayosodu_deltapresionestabilizacionmin"=>0.01,
    "parametrosensayosodu_velocidadminbajatension"=>1,
    //"parametrosensayosodu_velocidadmaxbajatension"=>1,
    "parametrosensayosodu_deltapresionbajatensionmin"=>0.01,
    "parametrosensayosodu_deltatempmincalor"=>0.1,
    "parametrosensayosodu_corrientemincalor"=>0.001,
    "parametrosensayosodu_potenciamincalor"=>0.001 ,
    "parametrosensayosodu_velocidadminventiladorcalor"=>1,
    "parametrosensayosodu_presionminapagadocompresor"=>0.01,
    "parametrosensayosodu_deltatempminfrio"=>0.1,
    "parametrosensayosodu_corrienteminfrio" =>0.001 ,
    "parametrosensayosodu_potenciaminfrio"=>0.001,
    "parametrosensayosodu_velocidadminventiladorfrio" =>1,
    "parametrosensayosodu_presionminfrio" =>0.01,
    "parametrosensayosodu_presioninicialmax" =>0.01,
    "parametrosensayosodu_deltapresionestabilizacionmax" =>0.01,
    "parametrosensayosodu_deltapresionbajatensionmax" =>0.01,
    "parametrosensayosodu_deltatempmaxcalor" =>0.1,
    "parametrosensayosodu_corrientemaxcalor" =>0.001 ,
    "parametrosensayosodu_potenciamaxcalor" =>0.001,
    "parametrosensayosodu_velocidadmaxventiladorcalor" =>1,
    "parametrosensayosodu_deltatempmaxfrio" =>0.1,
    "parametrosensayosodu_corrientemaxfrio" =>0.001,
    "parametrosensayosodu_potenciamaxfrio" =>0.001,
    "parametrosensayosodu_velocidadmaxventiladorfrio" =>1,
    "parametrosensayosodu_presionmaxfrio" =>0.01,
    "parametrosensayosodu_presionmaxrecuperacion" =>0.01
    // txtVelBajaTensionMax Compresor=>1
  );



  public function executeEdit(sfWebRequest $request)
  {
    $this->parametrosensayosodu = $this->getRoute()->getObject();
    
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value                          = $this->parametrosensayosodu->$attr * $this->config[$attr];
      $this->parametrosensayosodu->$attr  = $new_value; 
    }
    $this->form = $this->configuration->getForm($this->parametrosensayosodu);
  }

  protected function processForm(sfWebRequest $request, sfForm $form)
  {
    $values = $request->getParameter($form->getName());
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value      = $values[$attr] / $this->config[$attr];
      $values[$attr]  = (int)$new_value; 
    }
    
    $form->bind($values, $request->getFiles($form->getName()));
    if ($form->isValid())
    {
      $notice = $form->getObject()->isNew() ? 'The item was created successfully.' : 'The item was updated successfully.';

      try {
        $parametrosensayosodu = $form->save();
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

      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $parametrosensayosodu)));

      if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@parametrosensayosodu_new');
      }
      else
      {
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'parametrosensayosodu_edit', 'sf_subject' => $parametrosensayosodu));
      }
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }

}
