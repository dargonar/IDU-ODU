<?php

/**
 * Versiones form base class.
 *
 * @method Versiones getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseVersionesForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'versiones_id'          => new sfWidgetFormInputHidden(),
      'versiones_descripcion' => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'versiones_id'          => new sfValidatorChoice(array('choices' => array($this->getObject()->get('versiones_id')), 'empty_value' => $this->getObject()->get('versiones_id'), 'required' => false)),
      'versiones_descripcion' => new sfValidatorString(array('max_length' => 100, 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('versiones[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Versiones';
  }

}
