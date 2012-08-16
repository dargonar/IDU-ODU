<?php

/**
 * Placa form.
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class PlacaForm extends BasePlacaForm
{
  public function configure()
  {
    unset($this['id']);
    
    $this->widgetSchema['ensayoid'] = new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => false, 'method' => 'getNombre'));
    $this->validatorSchema['ensayoid'] = new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'required' => true, 'column'=>'id'));
    
    $this->widgetSchema['etiquetaid'] = new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'add_empty' => false, 'method' => 'getNombre'));
    $this->validatorSchema['etiquetaid'] = new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'required' => true, 'column'=>'id'));
    
    $this->widgetSchema['versionid'] = new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Version'), 'add_empty' => false, 'method' => 'getDescripcion'));
    $this->validatorSchema['versionid'] = new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Version'), 'required' => true, 'column'=>'id'));
  }
}
