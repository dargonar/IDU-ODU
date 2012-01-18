<?php

/**
 * Ensayosrealizadosidu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseEnsayosrealizadosiduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayosrealizadosidu_marca'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_modelo'                => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_codigo'                => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_serie'                 => new sfWidgetFormFilterInput(),
      'ensayosrealizadosidu_fecha'                 => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'ensayosrealizadosidu_aprobado'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_dcf'                   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_tiempoensayo'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_velocidadinicial'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_velocidadbajatension'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_velocidadlow'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_velocidadhigh'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_corrienteinicial'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_corrientebajatension'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_corrientelow'          => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_corrientehigh'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_corrientecalorinicial' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_hipot'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_fuga'                  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_observaciones'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_cantidadreimpresion'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosidu_usuario'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'orden_fabricacion'                          => new sfWidgetFormFilterInput(),
    ));

    $this->setValidators(array(
      'ensayosrealizadosidu_marca'                 => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_modelo'                => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_codigo'                => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_serie'                 => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_fecha'                 => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'ensayosrealizadosidu_aprobado'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosidu_dcf'                   => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_tiempoensayo'          => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosidu_velocidadinicial'      => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_velocidadbajatension'  => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_velocidadlow'          => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_velocidadhigh'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_corrienteinicial'      => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_corrientebajatension'  => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_corrientelow'          => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_corrientehigh'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_corrientecalorinicial' => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosidu_hipot'                 => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_fuga'                  => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_observaciones'         => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosidu_cantidadreimpresion'   => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosidu_usuario'               => new sfValidatorPass(array('required' => false)),
      'orden_fabricacion'                          => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayosrealizadosidu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayosrealizadosidu';
  }

  public function getFields()
  {
    return array(
      'ensayosrealizadosidu_id'                    => 'Number',
      'ensayosrealizadosidu_marca'                 => 'Text',
      'ensayosrealizadosidu_modelo'                => 'Text',
      'ensayosrealizadosidu_codigo'                => 'Text',
      'ensayosrealizadosidu_serie'                 => 'Text',
      'ensayosrealizadosidu_fecha'                 => 'Date',
      'ensayosrealizadosidu_aprobado'              => 'Number',
      'ensayosrealizadosidu_dcf'                   => 'Text',
      'ensayosrealizadosidu_tiempoensayo'          => 'Number',
      'ensayosrealizadosidu_velocidadinicial'      => 'Number',
      'ensayosrealizadosidu_velocidadbajatension'  => 'Number',
      'ensayosrealizadosidu_velocidadlow'          => 'Number',
      'ensayosrealizadosidu_velocidadhigh'         => 'Number',
      'ensayosrealizadosidu_corrienteinicial'      => 'Number',
      'ensayosrealizadosidu_corrientebajatension'  => 'Number',
      'ensayosrealizadosidu_corrientelow'          => 'Number',
      'ensayosrealizadosidu_corrientehigh'         => 'Number',
      'ensayosrealizadosidu_corrientecalorinicial' => 'Number',
      'ensayosrealizadosidu_hipot'                 => 'Text',
      'ensayosrealizadosidu_fuga'                  => 'Text',
      'ensayosrealizadosidu_observaciones'         => 'Text',
      'ensayosrealizadosidu_cantidadreimpresion'   => 'Number',
      'ensayosrealizadosidu_usuario'               => 'Text',
      'orden_fabricacion'                          => 'Text',
    );
  }
}
