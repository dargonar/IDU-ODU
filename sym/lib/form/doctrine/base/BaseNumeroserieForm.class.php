<?php

/**
 * Numeroserie form base class.
 *
 * @method Numeroserie getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseNumeroserieForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'      => new sfWidgetFormInputHidden(),
      'tipo'    => new sfWidgetFormInputText(),
      'numero'  => new sfWidgetFormInputText(),
      'maximo'  => new sfWidgetFormInputText(),
      'minimo'  => new sfWidgetFormInputText(),
      'prefijo' => new sfWidgetFormInputText(),
      'sufijo'  => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'      => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'tipo'    => new sfValidatorString(array('max_length' => 1)),
      'numero'  => new sfValidatorInteger(),
      'maximo'  => new sfValidatorInteger(),
      'minimo'  => new sfValidatorInteger(),
      'prefijo' => new sfValidatorString(array('max_length' => 10)),
      'sufijo'  => new sfValidatorInteger(),
    ));

    $this->widgetSchema->setNameFormat('numeroserie[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Numeroserie';
  }

}
