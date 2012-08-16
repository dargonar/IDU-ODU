<?php

/**
 * Resultadoensayo filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseResultadoensayoFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayook'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'error'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'tension5v'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'tension12v'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'tensioncorr'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'velocidades'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'numeroserie'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'fecha'         => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate())),
      'placaid'       => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Placa'), 'add_empty' => true)),
      'observaciones' => new sfWidgetFormFilterInput(),
      'dcf'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'paso'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'ensayook'      => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'error'         => new sfValidatorPass(array('required' => false)),
      'tension5v'     => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'tension12v'    => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'tensioncorr'   => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'velocidades'   => new sfValidatorPass(array('required' => false)),
      'numeroserie'   => new sfValidatorPass(array('required' => false)),
      'fecha'         => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'placaid'       => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Placa'), 'column' => 'id')),
      'observaciones' => new sfValidatorPass(array('required' => false)),
      'dcf'           => new sfValidatorPass(array('required' => false)),
      'paso'          => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('resultadoensayo_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Resultadoensayo';
  }

  public function getFields()
  {
    return array(
      'id'            => 'Number',
      'ensayook'      => 'Number',
      'error'         => 'Text',
      'tension5v'     => 'Number',
      'tension12v'    => 'Number',
      'tensioncorr'   => 'Number',
      'velocidades'   => 'Text',
      'numeroserie'   => 'Text',
      'fecha'         => 'Date',
      'placaid'       => 'ForeignKey',
      'observaciones' => 'Text',
      'dcf'           => 'Text',
      'paso'          => 'Number',
    );
  }
}
