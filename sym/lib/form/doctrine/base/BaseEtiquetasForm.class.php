<?php

/**
 * Etiquetas form base class.
 *
 * @method Etiquetas getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEtiquetasForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'etiquetas_id'     => new sfWidgetFormInputHidden(),
      'etiquetas_nombre' => new sfWidgetFormInputText(),
      'etiquetas_esidu'  => new sfWidgetFormInputText(),
      'es_activa'        => new sfWidgetFormInputText(),
      'es_bulto'         => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'etiquetas_id'     => new sfValidatorChoice(array('choices' => array($this->getObject()->get('etiquetas_id')), 'empty_value' => $this->getObject()->get('etiquetas_id'), 'required' => false)),
      'etiquetas_nombre' => new sfValidatorString(array('max_length' => 64)),
      'etiquetas_esidu'  => new sfValidatorInteger(array('required' => false)),
      'es_activa'        => new sfValidatorInteger(array('required' => false)),
      'es_bulto'         => new sfValidatorInteger(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('etiquetas[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Etiquetas';
  }

}
