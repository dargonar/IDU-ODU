<?php

/**
 * EnsayoFallaControlada form base class.
 *
 * @method EnsayoFallaControlada getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BaseEnsayoFallaControladaForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'                  => new sfWidgetFormInputHidden(),
      'ensayo_nro_serie'    => new sfWidgetFormInputText(),
      'fecha'               => new sfWidgetFormDateTime(),
      'falla_controlada_id' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('FallaControlada'), 'add_empty' => false)),
      'usuario_id'          => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('SfGuardUser'), 'add_empty' => false)),
      'linea'               => new sfWidgetFormInputText(),
      'dcf'                 => new sfWidgetFormInputText(),
    ));

    $this->setValidators(array(
      'id'                  => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'ensayo_nro_serie'    => new sfValidatorString(array('max_length' => 255)),
      'fecha'               => new sfValidatorDateTime(),
      'falla_controlada_id' => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('FallaControlada'))),
      'usuario_id'          => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('SfGuardUser'))),
      'linea'               => new sfValidatorString(array('max_length' => 255)),
      'dcf'                 => new sfValidatorString(array('max_length' => 255)),
    ));

    $this->widgetSchema->setNameFormat('ensayo_falla_controlada[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'EnsayoFallaControlada';
  }

}
