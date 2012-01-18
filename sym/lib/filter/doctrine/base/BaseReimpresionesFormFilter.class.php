<?php

/**
 * Reimpresiones filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseReimpresionesFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'reimpresiones_marca'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_modelo'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_codigo'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_serie'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_fecha'         => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'reimpresiones_aprobado'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_observaciones' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'reimpresiones_esidu'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'reimpresiones_marca'         => new sfValidatorPass(array('required' => false)),
      'reimpresiones_modelo'        => new sfValidatorPass(array('required' => false)),
      'reimpresiones_codigo'        => new sfValidatorPass(array('required' => false)),
      'reimpresiones_serie'         => new sfValidatorPass(array('required' => false)),
      'reimpresiones_fecha'         => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'reimpresiones_aprobado'      => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'reimpresiones_observaciones' => new sfValidatorPass(array('required' => false)),
      'reimpresiones_esidu'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('reimpresiones_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Reimpresiones';
  }

  public function getFields()
  {
    return array(
      'reimpresiones_id'            => 'Number',
      'reimpresiones_marca'         => 'Text',
      'reimpresiones_modelo'        => 'Text',
      'reimpresiones_codigo'        => 'Text',
      'reimpresiones_serie'         => 'Text',
      'reimpresiones_fecha'         => 'Date',
      'reimpresiones_aprobado'      => 'Number',
      'reimpresiones_observaciones' => 'Text',
      'reimpresiones_esidu'         => 'Number',
    );
  }
}
