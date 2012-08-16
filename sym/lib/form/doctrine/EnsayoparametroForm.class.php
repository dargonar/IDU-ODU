<?php

/**
 * Ensayoparametro form.
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormTemplate.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class EnsayoparametroForm extends BaseEnsayoparametroForm
{
  public function configure()
  {
    unset($this['id']);
    
    $this->widgetSchema['ensayoid'] = new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => false, 'method' => 'getNombre'));
    $this->validatorSchema['ensayoid'] = new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'required' => true, 'column'=>'id'));
    
  }
}
