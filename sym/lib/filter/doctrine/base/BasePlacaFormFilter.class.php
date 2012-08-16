<?php

/**
 * Placa filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BasePlacaFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'nombre'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'codigo'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'descripcion' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'extra1'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'extra2'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'extra3'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayoid'    => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => true)),
      'etiquetaid'  => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'add_empty' => true)),
      'versionid'   => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Version'), 'add_empty' => true)),
    ));

    $this->setValidators(array(
      'nombre'      => new sfValidatorPass(array('required' => false)),
      'codigo'      => new sfValidatorPass(array('required' => false)),
      'descripcion' => new sfValidatorPass(array('required' => false)),
      'extra1'      => new sfValidatorPass(array('required' => false)),
      'extra2'      => new sfValidatorPass(array('required' => false)),
      'extra3'      => new sfValidatorPass(array('required' => false)),
      'ensayoid'    => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Ensayo'), 'column' => 'id')),
      'etiquetaid'  => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Etiqueta'), 'column' => 'id')),
      'versionid'   => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Version'), 'column' => 'id')),
    ));

    $this->widgetSchema->setNameFormat('placa_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Placa';
  }

  public function getFields()
  {
    return array(
      'id'          => 'Number',
      'nombre'      => 'Text',
      'codigo'      => 'Text',
      'descripcion' => 'Text',
      'extra1'      => 'Text',
      'extra2'      => 'Text',
      'extra3'      => 'Text',
      'ensayoid'    => 'ForeignKey',
      'etiquetaid'  => 'ForeignKey',
      'versionid'   => 'ForeignKey',
    );
  }
}
