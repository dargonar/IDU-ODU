<?php

/**
 * Itemetiqueta form base class.
 *
 * @method Itemetiqueta getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseItemetiquetaForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'         => new sfWidgetFormInputHidden(),
      'font'       => new sfWidgetFormInputText(),
      'size'       => new sfWidgetFormInputText(),
      'bold'       => new sfWidgetFormInputText(),
      'italic'     => new sfWidgetFormInputText(),
      'xini'       => new sfWidgetFormInputText(),
      'xfin'       => new sfWidgetFormInputText(),
      'yini'       => new sfWidgetFormInputText(),
      'yfin'       => new sfWidgetFormInputText(),
      'variable'   => new sfWidgetFormInputText(),
      'tipo'       => new sfWidgetFormInputText(),
      'rot'        => new sfWidgetFormInputText(),
      'alignh'     => new sfWidgetFormInputText(),
      'alignv'     => new sfWidgetFormInputText(),
      'etiquetaid' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'add_empty' => true)),
      'valor'      => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'         => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'font'       => new sfValidatorString(array('max_length' => 128)),
      'size'       => new sfValidatorInteger(),
      'bold'       => new sfValidatorInteger(array('required' => false)),
      'italic'     => new sfValidatorInteger(array('required' => false)),
      'xini'       => new sfValidatorInteger(),
      'xfin'       => new sfValidatorInteger(),
      'yini'       => new sfValidatorInteger(),
      'yfin'       => new sfValidatorInteger(),
      'variable'   => new sfValidatorInteger(array('required' => false)),
      'tipo'       => new sfValidatorInteger(),
      'rot'        => new sfValidatorInteger(),
      'alignh'     => new sfValidatorInteger(),
      'alignv'     => new sfValidatorInteger(),
      'etiquetaid' => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'required' => false)),
      'valor'      => new sfValidatorString(array('max_length' => 128, 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('itemetiqueta[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Itemetiqueta';
  }

}
