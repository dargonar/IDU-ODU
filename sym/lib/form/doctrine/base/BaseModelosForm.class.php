<?php

/**
 * Modelos form base class.
 *
 * @method Modelos getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseModelosForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'modelos_id'           => new sfWidgetFormInputHidden(),
      'modelos_marca'        => new sfWidgetFormInputText(),
      'modelos_modelo'       => new sfWidgetFormInputText(),
      'modelos_codigo'       => new sfWidgetFormInputText(),
      'modelos_referencia'   => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Caracteristicastecnicasequipos'), 'add_empty' => false)),
      'modelos_ean13'        => new sfWidgetFormInputText(),
      'modelos_etiqueta'     => new sfWidgetFormInputText(),
      'modelos_etiquetacaja' => new sfWidgetFormInputText(),
      'modelos_logo'         => new sfWidgetFormInputText(),
      'modelos_conjunto'     => new sfWidgetFormInputText(),
      'modelos_capacidad'    => new sfWidgetFormInputText(),
      'modelos_codigoicsa'   => new sfWidgetFormInputText(),
      'modelos_descripcion'  => new sfWidgetFormInputText(),
      'modelos_dimensiones'  => new sfWidgetFormInputText(),
      'modelos_esidu'        => new sfWidgetFormInputText(),
      'es_activo'            => new sfWidgetFormInputText(),
      'background_bulto'     => new sfWidgetFormInputText(),
      'background_producto'  => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'modelos_id'           => new sfValidatorChoice(array('choices' => array($this->getObject()->get('modelos_id')), 'empty_value' => $this->getObject()->get('modelos_id'), 'required' => false)),
      'modelos_marca'        => new sfValidatorString(array('max_length' => 30, 'required' => false)),
      'modelos_modelo'       => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_codigo'       => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_referencia'   => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Caracteristicastecnicasequipos'), 'required' => false)),
      'modelos_ean13'        => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_etiqueta'     => new sfValidatorInteger(array('required' => false)),
      'modelos_etiquetacaja' => new sfValidatorInteger(array('required' => false)),
      'modelos_logo'         => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_conjunto'     => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_capacidad'    => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_codigoicsa'   => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_descripcion'  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_dimensiones'  => new sfValidatorString(array('max_length' => 100, 'required' => false)),
      'modelos_esidu'        => new sfValidatorInteger(array('required' => false)),
      'es_activo'            => new sfValidatorInteger(array('required' => false)),
      'background_bulto'     => new sfValidatorString(array('max_length' => 45)),
      'background_producto'  => new sfValidatorString(array('max_length' => 45)),
    ));

    $this->widgetSchema->setNameFormat('modelos[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Modelos';
  }

}
