<?php

/**
 * EnsayoFallaControlada filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseEnsayoFallaControladaFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayo_nro_serie'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'fecha'               => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'falla_controlada_id' => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('FallaControlada'), 'add_empty' => true)),
      'usuario_id'          => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('SfGuardUser'), 'add_empty' => true)),
      'linea'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'dcf'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'ensayo_nro_serie'    => new sfValidatorPass(array('required' => false)),
      'fecha'               => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'falla_controlada_id' => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('FallaControlada'), 'column' => 'id')),
      'usuario_id'          => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('SfGuardUser'), 'column' => 'id')),
      'linea'               => new sfValidatorPass(array('required' => false)),
      'dcf'                 => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayo_falla_controlada_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'EnsayoFallaControlada';
  }

  public function getFields()
  {
    return array(
      'id'                  => 'Number',
      'ensayo_nro_serie'    => 'Text',
      'fecha'               => 'Date',
      'falla_controlada_id' => 'ForeignKey',
      'usuario_id'          => 'ForeignKey',
      'linea'               => 'Text',
      'dcf'                 => 'Text',
    );
  }
}
