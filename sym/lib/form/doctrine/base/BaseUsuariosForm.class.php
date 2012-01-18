<?php

/**
 * Usuarios form base class.
 *
 * @method Usuarios getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseUsuariosForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'usuarios_id'          => new sfWidgetFormInputHidden(),
      'usuarios_password'    => new sfWidgetFormInputText(),
      'usuarios_descripcion' => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'usuarios_id'          => new sfValidatorChoice(array('choices' => array($this->getObject()->get('usuarios_id')), 'empty_value' => $this->getObject()->get('usuarios_id'), 'required' => false)),
      'usuarios_password'    => new sfValidatorString(array('max_length' => 20, 'required' => false)),
      'usuarios_descripcion' => new sfValidatorString(array('max_length' => 45)),
    ));

    $this->widgetSchema->setNameFormat('usuarios[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Usuarios';
  }

}
