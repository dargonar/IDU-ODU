<?php

/**
 * Parametrosensayosidu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseParametrosensayosiduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'parametrosensayosidu_referencia'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_descripcion'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_dcfs'                     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_modificado'               => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'parametrosensayosidu_retardostopinicial'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_retardostartmitad'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_timeoutcalor'             => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_timeoutfrio'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_retardostart2bajatension' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_tiempomodovelocidadbaja'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_tiempomodovelocidadalta'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_retardodesenergizado'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_final'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_temperatura'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadbajatensionmin'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadbajatensionmax'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrientebajatensionmin'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrientebajatensionmax'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadminmodovelbaja'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadmaxmodovelbaja'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrienteminmodovelbaja'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrientemaxmodovelbaja'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadminmodovelalta'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_velocidadmaxmodovelalta'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrienteminmodovelalta'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_corrientemaxmodovelalta'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_timeoutbajatension'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosidu_idversion'                => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'), 'add_empty' => true)),
      'es_activo'                                     => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'parametrosensayosidu_referencia'               => new sfValidatorPass(array('required' => false)),
      'parametrosensayosidu_descripcion'              => new sfValidatorPass(array('required' => false)),
      'parametrosensayosidu_dcfs'                     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_modificado'               => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'parametrosensayosidu_retardostopinicial'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_retardostartmitad'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_timeoutcalor'             => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_timeoutfrio'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_retardostart2bajatension' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_tiempomodovelocidadbaja'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_tiempomodovelocidadalta'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_retardodesenergizado'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_final'                    => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_temperatura'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadbajatensionmin'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadbajatensionmax'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrientebajatensionmin'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrientebajatensionmax'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadminmodovelbaja'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadmaxmodovelbaja'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrienteminmodovelbaja'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrientemaxmodovelbaja'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadminmodovelalta'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_velocidadmaxmodovelalta'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrienteminmodovelalta'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_corrientemaxmodovelalta'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_timeoutbajatension'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosidu_idversion'                => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Versiones'), 'column' => 'versiones_id')),
      'es_activo'                                     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('parametrosensayosidu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Parametrosensayosidu';
  }

  public function getFields()
  {
    return array(
      'parametrosensayosidu_id'                       => 'Number',
      'parametrosensayosidu_referencia'               => 'Text',
      'parametrosensayosidu_descripcion'              => 'Text',
      'parametrosensayosidu_dcfs'                     => 'Number',
      'parametrosensayosidu_modificado'               => 'Date',
      'parametrosensayosidu_retardostopinicial'       => 'Number',
      'parametrosensayosidu_retardostartmitad'        => 'Number',
      'parametrosensayosidu_timeoutcalor'             => 'Number',
      'parametrosensayosidu_timeoutfrio'              => 'Number',
      'parametrosensayosidu_retardostart2bajatension' => 'Number',
      'parametrosensayosidu_tiempomodovelocidadbaja'  => 'Number',
      'parametrosensayosidu_tiempomodovelocidadalta'  => 'Number',
      'parametrosensayosidu_retardodesenergizado'     => 'Number',
      'parametrosensayosidu_final'                    => 'Number',
      'parametrosensayosidu_temperatura'              => 'Number',
      'parametrosensayosidu_velocidadbajatensionmin'  => 'Number',
      'parametrosensayosidu_velocidadbajatensionmax'  => 'Number',
      'parametrosensayosidu_corrientebajatensionmin'  => 'Number',
      'parametrosensayosidu_corrientebajatensionmax'  => 'Number',
      'parametrosensayosidu_velocidadminmodovelbaja'  => 'Number',
      'parametrosensayosidu_velocidadmaxmodovelbaja'  => 'Number',
      'parametrosensayosidu_corrienteminmodovelbaja'  => 'Number',
      'parametrosensayosidu_corrientemaxmodovelbaja'  => 'Number',
      'parametrosensayosidu_velocidadminmodovelalta'  => 'Number',
      'parametrosensayosidu_velocidadmaxmodovelalta'  => 'Number',
      'parametrosensayosidu_corrienteminmodovelalta'  => 'Number',
      'parametrosensayosidu_corrientemaxmodovelalta'  => 'Number',
      'parametrosensayosidu_timeoutbajatension'       => 'Number',
      'parametrosensayosidu_idversion'                => 'ForeignKey',
      'es_activo'                                     => 'Number',
    );
  }
}
