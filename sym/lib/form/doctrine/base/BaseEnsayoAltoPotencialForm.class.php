<?php

/**
 * EnsayoAltoPotencial form base class.
 *
 * @method EnsayoAltoPotencial getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEnsayoAltoPotencialForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'                => new sfWidgetFormInputHidden(),
      'nro_serie'         => new sfWidgetFormInputText(),
      'orden_fabricacion' => new sfWidgetFormInputText(),
      'fecha'             => new sfWidgetFormDateTime(),
      'resultado'         => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'                => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'nro_serie'         => new sfValidatorString(array('max_length' => 255)),
      'orden_fabricacion' => new sfValidatorString(array('max_length' => 255, 'required' => false)),
      'fecha'             => new sfValidatorDateTime(array('required' => false)),
      'resultado'         => new sfValidatorInteger(),
    ));

    $this->widgetSchema->setNameFormat('ensayo_alto_potencial[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'EnsayoAltoPotencial';
  }

}
