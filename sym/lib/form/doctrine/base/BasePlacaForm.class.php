<?php

/**
 * Placa form base class.
 *
 * @method Placa getObject() Returns the current form's model object
 *
 * @package    sf_sandbox
 * @subpackage form
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormGeneratedTemplate.php 29553 2010-05-20 14:33:00Z Kris.Wallsmith $
 */
abstract class BasePlacaForm extends BaseFormDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'id'          => new sfWidgetFormInputHidden(),
      'nombre'      => new sfWidgetFormInputText(),
      'codigo'      => new sfWidgetFormInputText(),
      'descripcion' => new sfWidgetFormInputText(),
      'extra1'      => new sfWidgetFormInputText(),
      'extra2'      => new sfWidgetFormInputText(),
      'extra3'      => new sfWidgetFormInputText(),
      'ensayoid'    => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => false)),
      'etiquetaid'  => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'add_empty' => false)),
      'versionid'   => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Version'), 'add_empty' => false)),
    ));

    $this->setValidators(array(
      'id'          => new sfValidatorChoice(array('choices' => array($this->getObject()->get('id')), 'empty_value' => $this->getObject()->get('id'), 'required' => false)),
      'nombre'      => new sfValidatorString(array('max_length' => 128)),
      'codigo'      => new sfValidatorString(array('max_length' => 128)),
      'descripcion' => new sfValidatorString(array('max_length' => 128)),
      'extra1'      => new sfValidatorString(array('max_length' => 128)),
      'extra2'      => new sfValidatorString(array('max_length' => 128)),
      'extra3'      => new sfValidatorString(array('max_length' => 128)),
      'ensayoid'    => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'required' => false)),
      'etiquetaid'  => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'required' => false)),
      'versionid'   => new sfValidatorDoctrineChoice(array('model' => $this->getRelatedModelName('Version'), 'required' => false)),
    ));

    $this->widgetSchema->setNameFormat('placa[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Placa';
  }

}
