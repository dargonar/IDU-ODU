<?php

/**
 * Parametrosensayosodu filter form base class.
 *
 * @package    sf_sandbox
 * @subpackage filter
 * @author     Your name here
 * @version    SVN: $Id: sfDoctrineFormFilterGeneratedTemplate.php 29570 2010-05-21 14:49:47Z Kris.Wallsmith $
 */
abstract class BaseParametrosensayosoduFormFilter extends BaseFormFilterDoctrine
{
  public function setup()
  {
    $this->setWidgets(array(
      'parametrosensayosodu_ref'                            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_descripcion'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_modificado'                     => new sfWidgetFormFilterDate(array('from_date' => new sfWidgetFormDate(), 'to_date' => new sfWidgetFormDate(), 'with_empty' => false)),
      'parametrosensayosodu_dcfs'                           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempoinicialestabilizacion'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomaximoestabilizacion'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempobajatension'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomaximobajatension'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomedicioncalor'            => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomaximomedicioncalor'      => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomedicionfrio'             => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiemporecuperacionminima'       => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempomaximorecuperacionminima' => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_delayarranquecompresor'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempoapagadoentrecaloryfrio'   => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempocierrevalvula1'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempocierrevalvula2'           => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_tiempofinal'                    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presioninicialmin'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presioninicialmax'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltapresionestabilizacionmin'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltapresionestabilizacionmax'  => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_velocidadminbajatension'        => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltapresionbajatensionmin'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltapresionbajatensionmax'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltatempmincalor'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltatempmaxcalor'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_corrientemincalor'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_corrientemaxcalor'              => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_potenciamincalor'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_potenciamaxcalor'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_velocidadmaxventiladorcalor'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_velocidadminventiladorcalor'    => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presionminapagadocompresor'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltatempminfrio'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_deltatempmaxfrio'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_corrientemaxfrio'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_corrienteminfrio'               => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_potenciaminfrio'                => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_potenciamaxfrio'                => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_velocidadminventiladorfrio'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_velocidadmaxventiladorfrio'     => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presionminfrio'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presionmaxfrio'                 => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_presionmaxrecuperacion'         => new sfWidgetFormFilterInput(array('with_empty' => false)),
      'parametrosensayosodu_idversion'                      => new sfWidgetFormDoctrineChoice(array('model' => $this->getRelatedModelName('Versiones'), 'add_empty' => true)),
      'es_activo'                                           => new sfWidgetFormFilterInput(array('with_empty' => false)),
    ));

    $this->setValidators(array(
      'parametrosensayosodu_ref'                            => new sfValidatorPass(array('required' => false)),
      'parametrosensayosodu_descripcion'                    => new sfValidatorPass(array('required' => false)),
      'parametrosensayosodu_modificado'                     => new sfValidatorDateRange(array('required' => false, 'from_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 00:00:00')), 'to_date' => new sfValidatorDateTime(array('required' => false, 'datetime_output' => 'Y-m-d 23:59:59')))),
      'parametrosensayosodu_dcfs'                           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempoinicialestabilizacion'    => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomaximoestabilizacion'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempobajatension'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomaximobajatension'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomedicioncalor'            => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomaximomedicioncalor'      => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomedicionfrio'             => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiemporecuperacionminima'       => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempomaximorecuperacionminima' => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_delayarranquecompresor'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempoapagadoentrecaloryfrio'   => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempocierrevalvula1'           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempocierrevalvula2'           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_tiempofinal'                    => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presioninicialmin'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presioninicialmax'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltapresionestabilizacionmin'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltapresionestabilizacionmax'  => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_velocidadminbajatension'        => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltapresionbajatensionmin'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltapresionbajatensionmax'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltatempmincalor'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltatempmaxcalor'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_corrientemincalor'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_corrientemaxcalor'              => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_potenciamincalor'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_potenciamaxcalor'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_velocidadmaxventiladorcalor'    => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_velocidadminventiladorcalor'    => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presionminapagadocompresor'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltatempminfrio'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_deltatempmaxfrio'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_corrientemaxfrio'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_corrienteminfrio'               => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_potenciaminfrio'                => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_potenciamaxfrio'                => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_velocidadminventiladorfrio'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_velocidadmaxventiladorfrio'     => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presionminfrio'                 => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presionmaxfrio'                 => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_presionmaxrecuperacion'         => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
      'parametrosensayosodu_idversion'                      => new sfValidatorDoctrineChoice(array('required' => false, 'model' => $this->getRelatedModelName('Versiones'), 'column' => 'versiones_id')),
      'es_activo'                                           => new sfValidatorSchemaFilter('text', new sfValidatorInteger(array('required' => false))),
    ));

    $this->widgetSchema->setNameFormat('parametrosensayosodu_filters[%s]');

    $this->errorSchema = new sfValidatorErrorSchema($this->validatorSchema);

    $this->setupInheritance();

    parent::setup();
  }

  public function getModelName()
  {
    return 'Parametrosensayosodu';
  }

  public function getFields()
  {
    return array(
      'parametrosensayosodu_id'                             => 'Number',
      'parametrosensayosodu_ref'                            => 'Text',
      'parametrosensayosodu_descripcion'                    => 'Text',
      'parametrosensayosodu_modificado'                     => 'Date',
      'parametrosensayosodu_dcfs'                           => 'Number',
      'parametrosensayosodu_tiempoinicialestabilizacion'    => 'Number',
      'parametrosensayosodu_tiempomaximoestabilizacion'     => 'Number',
      'parametrosensayosodu_tiempobajatension'              => 'Number',
      'parametrosensayosodu_tiempomaximobajatension'        => 'Number',
      'parametrosensayosodu_tiempomedicioncalor'            => 'Number',
      'parametrosensayosodu_tiempomaximomedicioncalor'      => 'Number',
      'parametrosensayosodu_tiempomedicionfrio'             => 'Number',
      'parametrosensayosodu_tiemporecuperacionminima'       => 'Number',
      'parametrosensayosodu_tiempomaximorecuperacionminima' => 'Number',
      'parametrosensayosodu_delayarranquecompresor'         => 'Number',
      'parametrosensayosodu_tiempoapagadoentrecaloryfrio'   => 'Number',
      'parametrosensayosodu_tiempocierrevalvula1'           => 'Number',
      'parametrosensayosodu_tiempocierrevalvula2'           => 'Number',
      'parametrosensayosodu_tiempofinal'                    => 'Number',
      'parametrosensayosodu_presioninicialmin'              => 'Number',
      'parametrosensayosodu_presioninicialmax'              => 'Number',
      'parametrosensayosodu_deltapresionestabilizacionmin'  => 'Number',
      'parametrosensayosodu_deltapresionestabilizacionmax'  => 'Number',
      'parametrosensayosodu_velocidadminbajatension'        => 'Number',
      'parametrosensayosodu_deltapresionbajatensionmin'     => 'Number',
      'parametrosensayosodu_deltapresionbajatensionmax'     => 'Number',
      'parametrosensayosodu_deltatempmincalor'              => 'Number',
      'parametrosensayosodu_deltatempmaxcalor'              => 'Number',
      'parametrosensayosodu_corrientemincalor'              => 'Number',
      'parametrosensayosodu_corrientemaxcalor'              => 'Number',
      'parametrosensayosodu_potenciamincalor'               => 'Number',
      'parametrosensayosodu_potenciamaxcalor'               => 'Number',
      'parametrosensayosodu_velocidadmaxventiladorcalor'    => 'Number',
      'parametrosensayosodu_velocidadminventiladorcalor'    => 'Number',
      'parametrosensayosodu_presionminapagadocompresor'     => 'Number',
      'parametrosensayosodu_deltatempminfrio'               => 'Number',
      'parametrosensayosodu_deltatempmaxfrio'               => 'Number',
      'parametrosensayosodu_corrientemaxfrio'               => 'Number',
      'parametrosensayosodu_corrienteminfrio'               => 'Number',
      'parametrosensayosodu_potenciaminfrio'                => 'Number',
      'parametrosensayosodu_potenciamaxfrio'                => 'Number',
      'parametrosensayosodu_velocidadminventiladorfrio'     => 'Number',
      'parametrosensayosodu_velocidadmaxventiladorfrio'     => 'Number',
      'parametrosensayosodu_presionminfrio'                 => 'Number',
      'parametrosensayosodu_presionmaxfrio'                 => 'Number',
      'parametrosensayosodu_presionmaxrecuperacion'         => 'Number',
      'parametrosensayosodu_idversion'                      => 'ForeignKey',
      'es_activo'                                           => 'Number',
    );
  }
}
