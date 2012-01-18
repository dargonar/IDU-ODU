<?php

/**
 * Ensayosrealizadosodu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseEnsayosrealizadosoduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'ensayosrealizadosodu_marca'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_modelo'                   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_codigo'                   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_serie'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_fecha'                    => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'ensayosrealizadosodu_aprobado'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_dcf'                      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_diferenciadetemperatura'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_temperaturaambiente'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_humedad'                  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_tensionalta'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_tensionbaja'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_corrientealta'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_corrientebaja'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_potenciaalta'             => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_factordepotencia'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_velocidadalta'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_velocidadbaja'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_presioninicial'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_presionbajatension'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_presionensayo'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_presionrecuperacion'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_flags'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_tensionaltacalor'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_corrientealtacalor'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_factordepotenciacalor'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_potenciaaltacalor'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_velocidadaltacalor'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_temperaturaaltacalor'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_temperaturaambientecalor' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_humedadcalor'             => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_presionbajatensioncalor'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_vacio'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_hipot'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_fuga'                     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_observaciones'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_tiempoensayo'             => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_cantidadreimpresion'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'ensayosrealizadosodu_usuario'                  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'orden_fabricacion'                             => new sfWidgetFormFilterInput(),
    ));

    $this->setValidators(array(
      'ensayosrealizadosodu_marca'                    => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_modelo'                   => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_codigo'                   => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_serie'                    => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_fecha'                    => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'ensayosrealizadosodu_aprobado'                 => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosodu_dcf'                      => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_diferenciadetemperatura'  => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_temperaturaambiente'      => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_humedad'                  => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_tensionalta'              => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_tensionbaja'              => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_corrientealta'            => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_corrientebaja'            => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_potenciaalta'             => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_factordepotencia'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_velocidadalta'            => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_velocidadbaja'            => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_presioninicial'           => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_presionbajatension'       => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_presionensayo'            => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_presionrecuperacion'      => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_flags'                    => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_tensionaltacalor'         => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_corrientealtacalor'       => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_factordepotenciacalor'    => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_potenciaaltacalor'        => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_velocidadaltacalor'       => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_temperaturaaltacalor'     => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_temperaturaambientecalor' => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_humedadcalor'             => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_presionbajatensioncalor'  => new sfValidatorSchemaFilter('text', new sfValidatorNumber(array('required' => false))),
      'ensayosrealizadosodu_vacio'                    => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_hipot'                    => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_fuga'                     => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_observaciones'            => new sfValidatorPass(array('required' => false)),
      'ensayosrealizadosodu_tiempoensayo'             => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosodu_cantidadreimpresion'      => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'ensayosrealizadosodu_usuario'                  => new sfValidatorPass(array('required' => false)),
      'orden_fabricacion'                             => new sfValidatorPass(array('required' => false)),
    ));

    $this->widgetSchema->setNameFormat('ensayosrealizadosodu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Ensayosrealizadosodu';
  }

  public function getFields()
  {
    return array(
      'ensayosrealizadosodu_id'                       => 'Number',
      'ensayosrealizadosodu_marca'                    => 'Text',
      'ensayosrealizadosodu_modelo'                   => 'Text',
      'ensayosrealizadosodu_codigo'                   => 'Text',
      'ensayosrealizadosodu_serie'                    => 'Text',
      'ensayosrealizadosodu_fecha'                    => 'Date',
      'ensayosrealizadosodu_aprobado'                 => 'Number',
      'ensayosrealizadosodu_dcf'                      => 'Text',
      'ensayosrealizadosodu_diferenciadetemperatura'  => 'Number',
      'ensayosrealizadosodu_temperaturaambiente'      => 'Number',
      'ensayosrealizadosodu_humedad'                  => 'Number',
      'ensayosrealizadosodu_tensionalta'              => 'Number',
      'ensayosrealizadosodu_tensionbaja'              => 'Number',
      'ensayosrealizadosodu_corrientealta'            => 'Number',
      'ensayosrealizadosodu_corrientebaja'            => 'Number',
      'ensayosrealizadosodu_potenciaalta'             => 'Number',
      'ensayosrealizadosodu_factordepotencia'         => 'Number',
      'ensayosrealizadosodu_velocidadalta'            => 'Number',
      'ensayosrealizadosodu_velocidadbaja'            => 'Number',
      'ensayosrealizadosodu_presioninicial'           => 'Number',
      'ensayosrealizadosodu_presionbajatension'       => 'Number',
      'ensayosrealizadosodu_presionensayo'            => 'Number',
      'ensayosrealizadosodu_presionrecuperacion'      => 'Number',
      'ensayosrealizadosodu_flags'                    => 'Number',
      'ensayosrealizadosodu_tensionaltacalor'         => 'Number',
      'ensayosrealizadosodu_corrientealtacalor'       => 'Number',
      'ensayosrealizadosodu_factordepotenciacalor'    => 'Number',
      'ensayosrealizadosodu_potenciaaltacalor'        => 'Number',
      'ensayosrealizadosodu_velocidadaltacalor'       => 'Number',
      'ensayosrealizadosodu_temperaturaaltacalor'     => 'Number',
      'ensayosrealizadosodu_temperaturaambientecalor' => 'Number',
      'ensayosrealizadosodu_humedadcalor'             => 'Number',
      'ensayosrealizadosodu_presionbajatensioncalor'  => 'Number',
      'ensayosrealizadosodu_vacio'                    => 'Text',
      'ensayosrealizadosodu_hipot'                    => 'Text',
      'ensayosrealizadosodu_fuga'                     => 'Text',
      'ensayosrealizadosodu_observaciones'            => 'Text',
      'ensayosrealizadosodu_tiempoensayo'             => 'Number',
      'ensayosrealizadosodu_cantidadreimpresion'      => 'Number',
      'ensayosrealizadosodu_usuario'                  => 'Text',
      'orden_fabricacion'                             => 'Text',
    );
  }
}
