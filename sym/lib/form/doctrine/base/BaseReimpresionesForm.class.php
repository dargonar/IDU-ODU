<?php

/**
 * Reimpresiones form base class.
 *
 * @method Reimpresiones getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseReimpresionesForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'reimpresiones_id'            => new sfWidgetFormInputHidden(),
      'reimpresiones_marca'         => new sfWidgetFormInputText(),
      'reimpresiones_modelo'        => new sfWidgetFormInputText(),
      'reimpresiones_codigo'        => new sfWidgetFormInputText(),
      'reimpresiones_serie'         => new sfWidgetFormInputText(),
      'reimpresiones_fecha'         => new sfWidgetFormDateTime(),
      'reimpresiones_aprobado'      => new sfWidgetFormInputText(),
      'reimpresiones_observaciones' => new sfWidgetFormInputText(),
      'reimpresiones_esidu'         => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'reimpresiones_id'            => new sfValidatorChoice(array('choices' => array($this->getObject()->get('reimpresiones_id')), 'empty_value' => $this->getObject()->get('reimpresiones_id'), 'required' => false)),
      'reimpresiones_marca'         => new sfValidatorString(array('max_length' => 20)),
      'reimpresiones_modelo'        => new sfValidatorString(array('max_length' => 30)),
      'reimpresiones_codigo'        => new sfValidatorString(array('max_length' => 30)),
      'reimpresiones_serie'         => new sfValidatorString(array('max_length' => 20)),
      'reimpresiones_fecha'         => new sfValidatorDateTime(),
      'reimpresiones_aprobado'      => new sfValidatorInteger(),
      'reimpresiones_observaciones' => new sfValidatorString(array('max_length' => 100)),
      'reimpresiones_esidu'         => new sfValidatorInteger(),
    ));

    $this->widgetSchema->setNameFormat('reimpresiones[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Reimpresiones';
  }

}
