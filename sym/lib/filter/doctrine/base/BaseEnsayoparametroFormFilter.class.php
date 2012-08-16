<?php

/**
 * Ensayoparametro filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseEnsayoparametroFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'tag'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'paso'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'valor'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayoid' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Ensayo'), 'add_empty' => true)),
    ));

    $this->setValidators(array(
      'tag'      => new sfValidatorPass(array('required' => false)),
      'paso'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'valor'    => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayoid' => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Ensayo'), 'column' => 'id')),
    ));

    $this->widgetSchema->setNameFormat('ensayoparametro_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayoparametro';
  }

  public function getFields()
  {
    return array(
      'id'       => 'Number',
      'tag'      => 'Text',
      'paso'     => 'Number',
      'valor'    => 'Number',
      'ensayoid' => 'ForeignKey',
    );
  }
}
