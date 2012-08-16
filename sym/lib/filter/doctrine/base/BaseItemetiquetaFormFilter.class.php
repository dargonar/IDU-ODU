<?php

/**
 * Itemetiqueta filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseItemetiquetaFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'font'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'size'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'bold'       => new sfWidgetFormFilterInput(),
      'italic'     => new sfWidgetFormFilterInput(),
      'xini'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'xfin'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'yini'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'yfin'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'variable'   => new sfWidgetFormFilterInput(),
      'tipo'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'rot'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'alignh'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'alignv'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'etiquetaid' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Etiqueta'), 'add_empty' => true)),
      'valor'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'font'       => new sfValidatorPass(array('required' => false)),
      'size'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'bold'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'italic'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'xini'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'xfin'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'yini'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'yfin'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'variable'   => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'tipo'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'rot'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'alignh'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'alignv'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'etiquetaid' => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Etiqueta'), 'column' => 'id')),
      'valor'      => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('itemetiqueta_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Itemetiqueta';
  }

  public function getFields()
  {
    return array(
      'id'         => 'Number',
      'font'       => 'Text',
      'size'       => 'Number',
      'bold'       => 'Number',
      'italic'     => 'Number',
      'xini'       => 'Number',
      'xfin'       => 'Number',
      'yini'       => 'Number',
      'yfin'       => 'Number',
      'variable'   => 'Number',
      'tipo'       => 'Number',
      'rot'        => 'Number',
      'alignh'     => 'Number',
      'alignv'     => 'Number',
      'etiquetaid' => 'ForeignKey',
      'valor'      => 'Text',
    );
  }
}
