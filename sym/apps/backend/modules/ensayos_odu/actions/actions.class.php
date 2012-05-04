<?php

require_once dirname(__FILE__).'/../lib/ensayos_oduGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/ensayos_oduGeneratorHelper.class.php';

/**
 * ensayos_odu actions.
 *
 * @package    sf_sandbox
 * @subpackage ensayos_odu
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class ensayos_oduActions extends autoEnsayos_oduActions
{
  protected $config = array(
    /*"ensayosrealizadosodu_marca"=> ,
    "ensayosrealizadosodu_modelo"=> ,
    "ensayosrealizadosodu_codigo"=> ,
    "ensayosrealizadosodu_serie"=> ,
    "ensayosrealizadosodu_fecha"=> ,
    "ensayosrealizadosodu_aprobado"=> ,
    "ensayosrealizadosodu_dcf"=> ,
    */
    "ensayosrealizadosodu_diferenciadetemperatura"=> 0.1,
    "ensayosrealizadosodu_temperaturaambiente"=> 0.1,
    "ensayosrealizadosodu_humedad"=> 1,
    "ensayosrealizadosodu_tensionalta"=> 0.1,
    "ensayosrealizadosodu_tensionbaja"=> 0.1,
    "ensayosrealizadosodu_corrientealta"=> 0.001,
    "ensayosrealizadosodu_corrientebaja"=> 0.1,
    "ensayosrealizadosodu_potenciaalta"=> 0.001,
    "ensayosrealizadosodu_factordepotencia"=> 1,
    "ensayosrealizadosodu_velocidadalta"=> 1,
    "ensayosrealizadosodu_velocidadbaja"=> 0.1,
    "ensayosrealizadosodu_presioninicial"=> 0.01,
    "ensayosrealizadosodu_presionbajatension"=> 0.01,
    "ensayosrealizadosodu_presionensayo"=> 0.01,
    "ensayosrealizadosodu_presionrecuperacion"=> 0.1,
    /*"ensayosrealizadosodu_flags"=> ,*/
    "ensayosrealizadosodu_tensionaltacalor"=> 0.1,
    "ensayosrealizadosodu_corrientealtacalor"=> 0.001,
    "ensayosrealizadosodu_factordepotenciacalor"=> 1,
    "ensayosrealizadosodu_potenciaaltacalor"=> 0.001,
    "ensayosrealizadosodu_velocidadaltacalor"=> 1,
    "ensayosrealizadosodu_temperaturaaltacalor"=> 0.1,
    "ensayosrealizadosodu_temperaturaambientecalor"=> 0.1,
    "ensayosrealizadosodu_humedadcalor"=> 1,
    "ensayosrealizadosodu_presionbajatensioncalor"=> 0.01,
    /*"ensayosrealizadosodu_vacio"=> ,
    "ensayosrealizadosodu_hipot"=> ,
    "ensayosrealizadosodu_fuga"=> ,
    "ensayosrealizadosodu_observaciones"=> ,
    "ensayosrealizadosodu_tiempoensayo"=> ,
    "ensayosrealizadosodu_cantidadreimpresion"=> ,
    "ensayosrealizadosodu_usuario"=> ,
    "orden_fabricacion"=> ,*/

    );

  public function executeEdit(sfWebRequest $request)
  {
    $this->ensayosrealizadosodu = $this->getRoute()->getObject();
    
    foreach (array_keys($this->config) as $attr) 
    {
      $new_value                          = $this->ensayosrealizadosodu->$attr * $this->config[$attr];
      $this->ensayosrealizadosodu->$attr  = (double)$new_value; 
    }
    $this->form = $this->configuration->getForm($this->ensayosrealizadosodu);
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
        $ensayosrealizadosodu = $form->save();
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

      $this->dispatcher->notify(new sfEvent($this, 'admin.save_object', array('object' => $ensayosrealizadosodu)));

      /*if ($request->hasParameter('_save_and_add'))
      {
        $this->getUser()->setFlash('notice', $notice.' You can add another one below.');

        $this->redirect('@ensayosrealizadosodu_new');
      }
      else
      {*/
        $this->getUser()->setFlash('notice', $notice);

        $this->redirect(array('sf_route' => 'ensayosrealizadosodu_edit', 'sf_subject' => $ensayosrealizadosodu));
      /*}*/
    }
    else
    {
      $this->getUser()->setFlash('error', 'The item has not been saved due to some errors.', false);
    }
  }
}
