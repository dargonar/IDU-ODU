<?php

/**
 * Modelos form.
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class ModelosForm extends BaseModelosForm
{
  public function configure()
  {
    parent::configure();
    
    unset($this['modelos_id']);
    unset($this['modelos_etiqueta']);
    unset($this['modelos_etiquetacaja']);
    unset($this['modelos_conjunto']);
    unset($this['modelos_capacidad']);
    unset($this['modelos_codigoicsa']);
    unset($this['modelos_descripcion']);
    unset($this['modelos_dimensiones']);

    $this->validatorSchema['modelos_referencia'] = new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Caracteristicastecnicasequipos'), 'required' => false, 'column'=>'caracteristicastecnicasequipos_nombre'));
    
  }
}
