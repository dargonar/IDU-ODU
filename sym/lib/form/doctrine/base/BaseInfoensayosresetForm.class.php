<?php

/**
 * Infoensayosreset form base class.
 *
 * @method Infoensayosreset getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseInfoensayosresetForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'              => new sfWidgetFormInputHidden(),
      'fecha'           => new sfWidgetFormDateTime(),
      'numeroensayosok' => new sfWidgetFormInputText(),
      'usuario'         => new sfWidgetFormInputText(),
      'pc'              => new sfWidgetFormInputText(),
      'esidu'           => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'              => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'fecha'           => new sfValidatorDateTime(),
      'numeroensayosok' => new sfValidatorInteger(),
      'usuario'         => new sfValidatorString(array('max_length' => 20, 'required' => false)),
      'pc'              => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'esidu'           => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('infoensayosreset[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Infoensayosreset';
  }

}
