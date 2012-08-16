<?php

/**
 * Resultadoensayo form base class.
 *
 * @method Resultadoensayo getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseResultadoensayoForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'            => new sfWidgetFormInputHidden(),
      'ensayook'      => new sfWidgetFormInputText(),
      'error'         => new sfWidgetFormTextarea(),
      'tension5v'     => new sfWidgetFormInputText(),
      'tension12v'    => new sfWidgetFormInputText(),
      'tensioncorr'   => new sfWidgetFormInputText(),
      'velocidades'   => new sfWidgetFormTextarea(),
      'numeroserie'   => new sfWidgetFormInputText(),
      'fecha'         => new sfWidgetFormDateTime(),
      'placaid'       => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Placa'), 'add_empty' => true)),
      'observaciones' => new sfWidgetFormTextarea(),
      'dcf'           => new sfWidgetFormTextarea(),
      'paso'          => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'            => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'ensayook'      => new sfValidatorInteger(),
      'error'         => new sfValidatorString(array('max_length' => 2048)),
      'tension5v'     => new sfValidatorNumber(),
      'tension12v'    => new sfValidatorNumber(),
      'tensioncorr'   => new sfValidatorNumber(),
      'velocidades'   => new sfValidatorString(array('max_length' => 1024)),
      'numeroserie'   => new sfValidatorString(array('max_length' => 128)),
      'fecha'         => new sfValidatorDateTime(array('required' => false)),
      'placaid'       => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Placa'), 'required' => false)),
      'observaciones' => new sfValidatorString(array('max_length' => 2048, 'required' => false)),
      'dcf'           => new sfValidatorString(array('max_length' => 256)),
      'paso'          => new sfValidatorInteger(),
    ));

    $this->widgetSchema->setNameFormat('resultadoensayo[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Resultadoensayo';
  }

}
