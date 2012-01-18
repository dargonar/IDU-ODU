<?php

/**
 * Fallasodu form base class.
 *
 * @method Fallasodu getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseFallasoduForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'numerodefalla' => new sfWidgetFormInputHidden(),
      'descripcion'   => new sfWidgetFormInputText(),
      'prioridadalta' => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'numerodefalla' => new sfValidatorChoice(array('choices' => array($this->getObject()->get('numerodefalla')), 'empty_value' => $this->getObject()->get('numerodefalla'), 'required' => false)),
      'descripcion'   => new sfValidatorString(array('max_length' => 100)),
      'prioridadalta' => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('fallasodu[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Fallasodu';
  }

}
